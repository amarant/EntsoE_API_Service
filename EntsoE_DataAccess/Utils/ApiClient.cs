using EntsoE_DataModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using static EntsoE_DataModel.Country;

namespace EntsoE_DataAccess.Utils
{
    public class ApiClient
    {
        public ApiClient()
        {
        }

        public static async Task<ResponseObject<GL_MarketDocument>> Query_Generation_Forecast(Code countryCode, DateTime startDate, DateTime endDate)
        {
            var parameters = new List<Parameter> {
                 new Parameter("documentType", "A71", ParameterType.QueryString),
                 new Parameter("processType", "A01", ParameterType.QueryString),
                 new Parameter("periodStart", getFormatDate(startDate), ParameterType.QueryString),
                 new Parameter("periodEnd", getFormatDate(endDate), ParameterType.QueryString),
                 new Parameter("in_Domain", GetDomain(countryCode), ParameterType.QueryString)
            };

            return (await EnstoeRequestClient.Execute<GL_MarketDocument>(parameters));
        }

        private static string getFormatDate(DateTime date)
        {
            return $"{date.ToString("yyyyMMddHH")}00";
        }
    }
}
