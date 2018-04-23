using System;
using System.Collections.Generic;

namespace SampleWeb.Models
{
    public partial class tbStockSummary
    {
        public int ID { get; set; }
        public Nullable<System.Guid> ItemGUID { get; set; }
        public Nullable<int> CinemaID { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<System.DateTime> Accesstime { get; set; }
        public string StockStatus { get; set; }
        public Nullable<int> StockQty { get; set; }
        public Nullable<int> ThresholdQty { get; set; }
    }
}