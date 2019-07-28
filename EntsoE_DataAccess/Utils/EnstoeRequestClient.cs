using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EntsoE_DataAccess.Utils
{
    public class ResponseObject<T>
    {
        public T PayLoad { get; set; }
        public bool HasData { get; set; }
        public string Message { get; set; }
        public bool MaxLimitReached { get; set; }
    }

    public class EnstoeRequestClient
    {
        private static readonly int _requestsPerMinute = 300;
        private static int _lastRequestTime;

        static readonly string _baseUrl = @"https://transparency.entsoe.eu/api?securityToken=7997003c-054a-45b0-943e-ca8525a43fe5";
        private static readonly Lazy<EnstoeRequestClient> lazy = new Lazy<EnstoeRequestClient>(() => new EnstoeRequestClient());

        public static EnstoeRequestClient Instance { get { return lazy.Value; } }

        readonly static IRestClient _client;

        static EnstoeRequestClient()
        {
            _client = new RestClient(_baseUrl);
        }

        static object locker = new object();

        static IRestClient Client
        {
            get
            {
                lock (locker)
                {
                    if (_client == null)
                    {
                        return new RestClient(_baseUrl);
                    }

                    return _client;
                }
            }
        }

        public static async Task<ResponseObject<T>> Execute<T>(List<Parameter> parameters) where T : new()
        {
            var returnObj = new ResponseObject<T>();

            var request = new RestRequest(Method.GET);

            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Connection", "keep-alive");
            request.AddHeader("accept-encoding", "gzip, deflate");
            request.AddHeader("Host", "transparency.entsoe.eu");
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Accept", "*/*");

            foreach (var item in parameters)
            {
                request.AddParameter(item);
            }

            await Task.Run(async () =>
            {
                int elapsedTime = Environment.TickCount - _lastRequestTime;
                int pause = (60 / _requestsPerMinute) * 1000;
                int wait = pause - elapsedTime;
                if (wait > -2)
                {
                    await Task.Delay(wait);
                }
            });

            IRestResponse response = await Client.ExecuteGetTaskAsync(request);
            _lastRequestTime = Environment.TickCount;

            if (response.ErrorException != null)
            {
                returnObj.Message = "Error retrieving response.  Check inner details for more info.";
                returnObj.HasData = false;
                returnObj.MaxLimitReached = false;
                return returnObj;
            }

            if (response.Content.Contains("Acknowledgement_MarketDocument") && response.Content.Contains("No matching"))
            {
                returnObj.Message = "No results returned";
                returnObj.HasData = false;
                returnObj.MaxLimitReached = false;
                return returnObj;
            }

            //Max allowed requests per minute
            if (response.Content.ToLower().Contains("max allowed requests per minute"))
            {
                returnObj.Message = "Request limit reached";
                returnObj.HasData = false;
                returnObj.MaxLimitReached = true;
                return returnObj;
            }
            
            var serial = new XmlSerializer(typeof(T));
            var strReader = new StringReader(response.Content);
            
            returnObj.PayLoad = (T)serial.Deserialize(strReader);
            returnObj.HasData = true;
            returnObj.MaxLimitReached = false;

            return returnObj;
        }
    }
}
