using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntsoE_DataModel.Data
{
    [Table("GenForecastTimeSeries", Schema = "entsoe")]
    public class GenForecastTimeSeries : RequestTimeSeries, IRequestTimeSeries
    {
        [ForeignKey("GenForecastMeta")]
        public Int64 MetaId { get; set; }
        public GenForecastMeta GenForecastMeta { get; set; }
    }
}
