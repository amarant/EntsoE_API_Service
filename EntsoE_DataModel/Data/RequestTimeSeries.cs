using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntsoE_DataModel.Data
{
    public class RequestTimeSeries
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 Id { get; set; }

        public int Position { get; set; }
        public double Quantity { get; set; }
    }
}
