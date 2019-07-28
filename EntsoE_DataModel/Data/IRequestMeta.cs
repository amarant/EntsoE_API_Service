using System;
using System.Collections.Generic;

namespace EntsoE_DataModel.Data
{
    public interface IRequestMeta
    {
        Int64 Id { get; set; }

        DateTime StartPeriod { get; set; }
        DateTime EndPeriod { get; set; }
        int IntervalMins { get; set; }
        int mRID { get; set; }
        string CountryCode { get; set; }
        string DocumentType { get; set; }
        string ProcessType { get; set; }
        DateTime InsertedOn { get; set; }
        int RowCount { get; set; }

        GenForecastLog GenForecastRequestLog { get; set; }
        long GenForecastRequestLogId { get; set; }
        ICollection<GenForecastTimeSeries> TimeSeries { get; set; }
    }
}