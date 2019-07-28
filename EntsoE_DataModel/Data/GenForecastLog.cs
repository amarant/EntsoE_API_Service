using System.Collections.Generic;

namespace EntsoE_DataModel.Data
{
    public class GenForecastLog : RequestLog, IRequestLog
    {
        public GenForecastLog()
        {

        }

        public ICollection<GenForecastMeta> GenForecastMeta { get; set; }
    }
}
