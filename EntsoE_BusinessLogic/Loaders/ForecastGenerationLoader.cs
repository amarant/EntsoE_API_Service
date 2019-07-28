using EntsoE_DataModel;
using EntsoE_DataModel.Data;
using System;
using System.Linq;
using System.Threading.Tasks;
using EntsoE_BusinessLogic.Helpers;
using EntsoE_DataAccess.Utils;
using System.Collections.Generic;

namespace EntsoE_BusinessLogic.Loaders
{
    public class ForecastGenerationLoader : ILoader
    {
        static readonly string documentType = "A71";
        static readonly string requestType = "Generation Forecast";

        public ForecastGenerationLoader()
        {
        }

        public async Task Run()
        {
            //remove duplicate entries
            await new RequestLogHelper<GenForecastLog, GenForecastMeta>().RemoveDuplicates();

            var countries = Enum.GetValues(typeof(Country.Code)).Cast<Country.Code>();

            //Find and missing request periods and fill in
            countries.ToList().ForEach(async i => { await new RequestLogHelper<GenForecastLog, GenForecastMeta>().AddMissingRequestData(ApiClient.Query_Generation_Forecast, documentType, requestType); });
            //retry and failed requests
            countries.ToList().ForEach(async i => await new RequestLogHelper<GenForecastLog, GenForecastMeta>().RetryFailedRequests(ApiClient.Query_Generation_Forecast,i, documentType, requestType ));

            while (true)
            {
                countries.ToList().ForEach(async i => await new RequestLogHelper<GenForecastLog, GenForecastMeta>().DownloadData(ApiClient.Query_Generation_Forecast, i, documentType, requestType));
                await Task.Delay(EntsoeHelper.PollingCount);
            }
        }
    }
}
