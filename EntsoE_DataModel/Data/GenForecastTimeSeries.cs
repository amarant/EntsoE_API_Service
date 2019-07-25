using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntsoE_DataModel.Data
{
    [Table("GenForecastTimeSeries", Schema = "entsoe")]
    public class GenForecastTimeSeries
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 Id { get; set; }

        [ForeignKey("GenForecastMeta")]
        public Int64 MetaId { get; set; }
        public GenForecastMeta GenForecastMeta { get; set; }

        public int Position { get; set; }
        public double Quantity { get; set; }

        public GenForecastTimeSeries()
        {

        }
    }
}
