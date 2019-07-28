using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntsoE_DataModel.Data
{
    [Table("GenForecastMeta", Schema = "entsoe")]
    public class GenForecastMeta : RequestMeta, IRequestMeta
    {
        [ForeignKey("GenForecastRequestLog")]
        public Int64 GenForecastRequestLogId { get; set; }
        public GenForecastLog GenForecastRequestLog { get; set; }

        public ICollection<GenForecastTimeSeries> TimeSeries { get; set; }
    }
}
