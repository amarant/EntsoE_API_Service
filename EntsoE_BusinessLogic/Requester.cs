using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;
using static EntsoE_DataModel.Domain;
using EntsoE_DataAccess.Utils;
using Newtonsoft.Json;
using System.Xml;

namespace EntsoE_BusinessLogic
{
    public class Requester
    {
        public static async Task<JObject> QueryGenerationForecast(DomainName countryCode, DateTime startDate, DateTime endDate)
        {
            var xml = new XmlDocument();
            
            xml.LoadXml(await EntsoE_RequestClient.Query_Generation_Forecast(countryCode, startDate, endDate));

            return JObject.Parse(JsonConvert.SerializeXmlNode(xml));
        }
    }
}
