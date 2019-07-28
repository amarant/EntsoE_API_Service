using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntsoE_DataModel.Data
{
    public class RequestMeta
    {
        public RequestMeta()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 Id { get; set; }

        public DateTime StartPeriod { get; set; }
        public DateTime EndPeriod { get; set; }

        public int IntervalMins { get; set; }

        public int mRID { get; set; }

        public string CountryCode { get; set; }

        public string DocumentType { get; set; }

        public string ProcessType { get; set; }

        public DateTime InsertedOn { get; set; }

        public int RowCount { get; set; }

        public ICollection<RequestTimeSeries> TimeSeries { get; set; }
    }
}
