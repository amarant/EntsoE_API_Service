using System;
using System.Collections.Generic;

namespace EntsoE_DataModel.Data
{
    public interface IRequestLog
    {
        Int64 Id { get; set; }

        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        string CountryCode { get; set; }
        string RequestType { get; set; }

        DateTime InsertedOn { get; set; }

        string Message { get; set; }
        bool HasData { get; set; }
        int RetryCount { get; set; }

        ICollection<GenForecastMeta> GenForecastMeta { get; set; }
    }
}