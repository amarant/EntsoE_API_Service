using System;

namespace EntsoE_DataModel.Data
{
    public interface IRequestTimeSeries
    {
        Int64 Id { get; set; }

        int Position { get; set; }
        double Quantity { get; set; }
        GenForecastMeta GenForecastMeta { get; set; }
        long MetaId { get; set; }
    }
}