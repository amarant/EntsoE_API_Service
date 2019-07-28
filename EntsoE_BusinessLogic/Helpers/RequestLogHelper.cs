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

namespace EntsoE_BusinessLogic.Helpers
{
    public class RequestLogHelper<T, U> where T : RequestLog where U : RequestMeta
    {
        readonly Func<ApplicationDbContext> _factory = () => { return new ApplicationDbContext(); };
        static CancellationTokenSource cancellationSource;

        public RequestLogHelper()
        {
            cancellationSource = new CancellationTokenSource();
        }

        public async Task DownloadData(Func<Country.Code, DateTime, DateTime, Task<ResponseObject<GL_MarketDocument>>> getMarketDataDoc, Country.Code country, string documnentType, string requestType)
        {
            var queryDataBlock = new TransformBlock<(DateTime, DateTime, Country.Code), RequestLog>(async queryData =>
            {
                
                var data = await GetData(getMarketDataDoc, queryData.Item3, queryData.Item1, queryData.Item2, documnentType, requestType);

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

            var saveToDatabaseBlock = new ActionBlock<RequestLog>(async requestData =>
            {
                using (var _context = _factory.Invoke())
                {
                    await _context.Set<T>().AddAsync((T)requestData);
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

            var startDate = EntsoeHelper.MinDate;

            using (var _context = new ApplicationDbContext())
            {
                startDate = await _context.Set<U>().Where(i => i.CountryCode == country.ToString()).MaxAsync(i => i.EndPeriod);
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

        public static async Task<RequestLog> GetData(Func<Country.Code, DateTime, DateTime, Task<ResponseObject<GL_MarketDocument>>> getMarketDataDoc, Country.Code country, DateTime start, DateTime end, string documnentType, string requestType)
        {
            var result = await getMarketDataDoc(country, start, end);

            var requestData = new List<RequestMeta>();

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
                        requestData.Add(new RequestMeta
                        {
                            CountryCode = country.ToString(),
                            DocumentType = documnentType,
                            mRID = item.mRID,
                            IntervalMins = EntsoeHelper.GetIntervalInMinutes(item.Period.resolution),
                            ProcessType = item.curveType,
                            StartPeriod = DateTime.Parse(item.Period.timeInterval.start),
                            EndPeriod = DateTime.Parse(item.Period.timeInterval.end),
                            TimeSeries = item.Period.Point.ToList().Select(p => new RequestTimeSeries { Position = p.position, Quantity = p.quantity }).ToList(),
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

            var requestLog = new RequestLog
            {
                CountryCode = country.ToString(),
                StartDate = start,
                EndDate = end,
                HasData = result.HasData,
                Message = result.Message,
                RequestType = requestType,
                RequestMeta = requestData,
            };
            return requestLog;
        }

        public async Task RetryFailedRequests(Func<Country.Code, DateTime, DateTime, Task<ResponseObject<GL_MarketDocument>>> getMarketDataDoc, Country.Code country, string documnentType, string requestType)
        {
            //get failed requests
            var failedRequests = new List<T>();

            using (var context = _factory.Invoke())
            {
                //get requests that failed due to api limit breach
                failedRequests.AddRange(await context.Set<T>().Where(l => l.CountryCode == country.ToString()
                                                               && (!l.HasData && l.Message.ToLower().Contains("limit"))).ToListAsync());

                //get requests that failed due to reasons unknown
                failedRequests.AddRange(await context.Set<T>().Where(l => l.CountryCode == country.ToString()
                                                               && (!l.HasData && !l.Message.ToLower().Contains("no results"))).ToListAsync());

                foreach (var item in failedRequests)
                {
                    if (Enum.TryParse(item.CountryCode, out Country.Code countryName))
                    {
                        var data = await GetData(getMarketDataDoc, countryName,item.StartDate, item.EndDate, documnentType, requestType);

                        if (data.HasData)
                            context.Set<T>().Update(item);
                        else
                            item.RetryCount++;
                    }
                    else
                        item.RetryCount = EntsoeHelper.RetryCount;

                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task AddMissingRequestData(Func<Country.Code, DateTime, DateTime, Task<ResponseObject<GL_MarketDocument>>> getMarketDataDoc, string documnentType, string requestType)
        {
            var queryDataBlock = new TransformBlock<(DateTime, DateTime, Country.Code), RequestLog>(async queryData =>
            {

                var data = await GetData(getMarketDataDoc, queryData.Item3, queryData.Item1, queryData.Item2, documnentType, requestType);

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

            var saveToDatabaseBlock = new ActionBlock<RequestLog>(async requestData =>
            {
                using (var _context = _factory.Invoke())
                {
                    await _context.Set<T>().AddAsync((T)requestData);
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

            var countries = Enum.GetValues(typeof(Country.Code)).Cast<Country.Code>();

            var missingRequests = new List<(bool, List<(DateTime, DateTime)>)>();

            countries.ToList().ForEach(async i => {

                var missingRequest = await new RequestLogHelper<GenForecastLog, GenForecastMeta>().GetMissingRequestDatesByCountry(i);
                if (missingRequest.Item1)
                    missingRequest.Item2.ForEach(r => queryDataBlock.Post((r.Item1, r.Item2, i)));
            });

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

        async Task<(bool, List<(DateTime, DateTime)>)> GetMissingRequestDatesByCountry(Country.Code country)
        {
            var returnList = new List<(DateTime, DateTime)>();
            var allRequestDateRanges = new List<T>();

            using (var context = _factory.Invoke())
            {
                //get all requests
                allRequestDateRanges = await context.Set<T>().Where(l => l.CountryCode == country.ToString()).ToListAsync();
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
                var missingDates = Enumerable.Range(0, (int)(allRequestDateRanges.Where(i => i.EndDate < DateTime.Now.Date).Select(r => r.EndDate).Max() - EntsoeHelper.MinDate).TotalDays + 1)
                                             .Select(i => EntsoeHelper.MinDate.AddDays(i)).Except(contDateRange.Distinct());

                var missingMonths = missingDates.GroupBy(x => new { x.Month, x.Year })
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

        public async Task RemoveDuplicates()
        {
            using (var context = _factory.Invoke())
            {
                var query = context.Set<T>().GroupBy(x => new { x.StartDate, x.EndDate, x.CountryCode, x.RequestType })
                                                          .SelectMany(x => x.OrderBy(y => y.Id).Skip(1));

                foreach (var dupe in query)
                {
                    context.Set<T>().Remove(dupe);
                }

                await context.SaveChangesAsync();
            }
        }
    }
}
