using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntsoE_DataModel.Data
{
    public class RequestLog
    {
        public RequestLog()
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

        public ICollection<RequestMeta> RequestMeta { get; set; }
    }
}
