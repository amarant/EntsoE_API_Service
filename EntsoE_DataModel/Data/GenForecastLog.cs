using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntsoE_DataModel.Data
{
    public class GenForecastLog
    {
        public GenForecastLog()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 Id { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CountryCode { get; set; }
        public string RequestType { get; set; }

        public DateTime InsertedOn { get; set; }

        public string Message { get; set; }
        public bool HasData { get; set; }
        public int RetryCount { get; set; }

        public ICollection<GenForecastMeta> GenForecastMeta { get; set; }

    }
}
