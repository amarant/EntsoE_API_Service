using EntsoE_DataAccess.Data;
using EntsoE_DataAccess.Utils;
using EntsoE_DataModel;
using EntsoE_DataModel.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace EntsoE_BusinessLogic.Loaders
{
    public class LoaderBase : ILoader
    {
        readonly Func<ApplicationDbContext> _factory = () => { return new ApplicationDbContext(); };
        static CancellationTokenSource cancellationSource;
        int _retryCount = 5;
        int _pollingCount = 900000;

        readonly DateTime minDate = new DateTime(2015, 1, 1);

        public LoaderBase(int retryCount, int pollingCount)
        {
            _retryCount = retryCount;
            _pollingCount = pollingCount;
            cancellationSource = new CancellationTokenSource();
        }

        public async Task Run()
        {
            await removeDuplicateDbEntries();

            var countries = Enum.GetValues(typeof(Country.Code))
                   .Cast<Country.Code>();

            countries.ToList().ForEach(async i => await getMissingRequestDatesByCountry(i));

            while (true)
            {
                countries.ToList().ForEach(async i => await DownloadGererationForecasts(i));
                await Task.Delay(_pollingCount);
            }
        }

        async Task DownloadGererationForecasts(Country.Code country)
        {
            var queryDataBlock = new TransformBlock<(DateTime, DateTime, Country.Code), GenForecastLog>(async queryData =>
            {
                var data = await GetData(queryData.Item1, queryData.Item2, queryData.Item3);

                if (data.HasData)
                    Console.WriteLine($"-------------------------- DATA RETURNED FOR : {queryData.Item3.ToString()}");
                else
                    Console.WriteLine($"-------------------------- NO DATA : {queryData.Item3.ToString()} --------------------------");

                return data;
            }, new ExecutionDataflowBlockOptions
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount / 2,
                SingleProducerConstrained = true,
                EnsureOrdered = false,
                CancellationToken = cancellationSource.Token
            });

            var saveToDatabaseBlock = new ActionBlock<GenForecastLog>(async requestData =>
            {
                using (var _context = _factory.Invoke())
                {
                    await _context.GenForecastRequestLogs.AddAsync(requestData);
                    await _context.SaveChangesAsync();

                    Console.WriteLine("DATA SAVED");
                }
            }, new ExecutionDataflowBlockOptions
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount / 2,
                SingleProducerConstrained = true,
                EnsureOrdered = false,
                CancellationToken = cancellationSource.Token
            });

            queryDataBlock.LinkTo(saveToDatabaseBlock, new DataflowLinkOptions { PropagateCompletion = true });

            var startDate = minDate;

            using (var _context = new ApplicationDbContext())
            {
                startDate = await _context.GenForecastMeta.Where(i => i.CountryCode == country.ToString()).MaxAsync(i => i.EndPeriod);
            }

            var endDate = DateTime.Now;

            DateTime tempDate = startDate;
            int requestCount = 0;

            while (tempDate < endDate)
            {
                requestCount++;
                queryDataBlock.Post((tempDate, tempDate.AddMonths(1), country));

                tempDate = tempDate.AddMonths(1);
            }

            try
            {
                queryDataBlock.Complete();
                await saveToDatabaseBlock.Completion;
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine($"Request Limit reached. error : {ex.Message}");
            }

        }

        async Task removeDuplicateDbEntries()
        {
            using (var context = _factory.Invoke())
            {
                var query = context.GenForecastRequestLogs.GroupBy(x => new { x.StartDate, x.EndDate, x.CountryCode, x.RequestType })
                                                          .SelectMany(x => x.OrderBy(y => y.Id).Skip(1));

                foreach (var dupe in query)
                {
                    context.GenForecastRequestLogs.Remove(dupe);
                }

                await context.SaveChangesAsync();
            }
        }

        async Task retryFailedRequests(Country.Code country)
        {
            //get failed requests
            List<GenForecastLog> failedRequests = new List<GenForecastLog>();

            using (var context = _factory.Invoke())
            {
                //get requests that failed due to api limit breach
                failedRequests.AddRange(await context.GenForecastRequestLogs.Where(l => l.CountryCode == country.ToString()
                                                                                               && (!l.HasData && l.Message.ToLower().Contains("limit"))).ToListAsync());

                //get requests that failed due to reasons unknown
                failedRequests.AddRange(await context.GenForecastRequestLogs.Where(l => l.CountryCode == country.ToString()
                                                                                               && (!l.HasData && !l.Message.ToLower().Contains("no results"))).ToListAsync());

                foreach (var item in failedRequests)
                {
                    if (Enum.TryParse(item.CountryCode, out Country.Code countryName))
                    {
                        var data = await GetData(item.StartDate, item.EndDate, countryName);

                        if (data.HasData)
                            context.GenForecastRequestLogs.Update(item);
                        else
                            item.RetryCount++;
                    }
                    else
                        item.RetryCount = _retryCount;

                    await context.SaveChangesAsync();
                }
            }
        }

        async Task<(bool, List<(DateTime, DateTime)>)> getMissingRequestDatesByCountry(Country.Code country)
        {
            var returnList = new List<(DateTime, DateTime)>();
            List<GenForecastLog> allRequestDateRanges = new List<GenForecastLog>();

            using (var context = _factory.Invoke())
            {
                //get all requests
                allRequestDateRanges = await context.GenForecastRequestLogs.Where(l => l.CountryCode == country.ToString()).ToListAsync();
            }
            //get continuation date rages
            var contDateRange = new List<DateTime>();

            foreach (var item in allRequestDateRanges)
            {
                var tempDate = item.StartDate;

                while (tempDate < item.EndDate)
                {
                    contDateRange.Add(tempDate);
                    tempDate = tempDate.AddDays(1);
                }
            }

            if (allRequestDateRanges.Count > 0)
            {
                //find any missing dates - holes in the requests
                var missingDates = Enumerable.Range(0, (int)(allRequestDateRanges.Where(i => i.EndDate < DateTime.Now.Date).Select(r => r.EndDate).Max() - minDate).TotalDays + 1)
                                             .Select(i => minDate.AddDays(i)).Except(contDateRange.Distinct());

                var missingMonths = missingDates.GroupBy(x => new { Month = x.Month, Year = x.Year })
                                                .ToDictionary(g => g.Key, g => g.Count());

                foreach (var item in missingMonths)
                {
                    var start = new DateTime(item.Key.Year, item.Key.Month, 1);
                    var end = start.AddMonths(1);

                    returnList.Add((start, end));
                }
                return ((missingMonths.Count > 0), returnList);
            }
            return (false, returnList);
        }

        static async Task<GenForecastLog> GetData(DateTime start, DateTime end, Country.Code country)
        {
            Console.WriteLine($"quering for : {start.ToString("dd/MM/yyyy HH:mm:ss")} to : {end.ToString("dd/MM/yyyy HH:mm:ss")}");

            var result = await ApiClient.Query_Generation_Forecast(country, start, end);

            var genData = new List<GenForecastMeta>();

            if (result.MaxLimitReached)
            {
                cancellationSource.Cancel();
            }

            if (result.HasData)
            {
                try
                {
                    var timeSeries = result.PayLoad.TimeSeries.ToList();

                    foreach (var item in timeSeries)
                    {
                        genData.Add(new GenForecastMeta
                        {
                            CountryCode = country.ToString(),
                            DocumentType = "A71",
                            mRID = item.mRID,
                            IntervalMins = getIntervalInMinutes(item.Period.resolution),
                            ProcessType = item.curveType,
                            StartPeriod = DateTime.Parse(item.Period.timeInterval.start),
                            EndPeriod = DateTime.Parse(item.Period.timeInterval.end),
                            TimeSeries = item.Period.Point.ToList().Select(p => new GenForecastTimeSeries { Position = p.position, Quantity = p.quantity }).ToList(),
                            RowCount = item.Period.Point.Count()
                        });
                    }

                    Console.WriteLine("data returned from api");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error : {ex.Message}");
                }
            }

            var requestLog = new GenForecastLog
            {
                CountryCode = country.ToString(),
                StartDate = start,
                EndDate = end,
                HasData = result.HasData,
                Message = result.Message,
                RequestType = "Generation forecast",
                GenForecastMeta = genData,
            };
            return requestLog;
        }

        static int getIntervalInMinutes(string code)
        {
            switch (code)
            {
                case "PT60M":
                    return 60;
                case "PT1H":
                    return 60;
                case "PT30M":
                    return 30;
                case "PT15M":
                    return 15;
                case "P1Y":
                    return 525600;
                default:
                    return 1;
            }
        }
    }
}
