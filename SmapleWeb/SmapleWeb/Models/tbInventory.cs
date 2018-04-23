using System;
using System.Collections.Generic;

namespace SampleWeb.Models
{
    public partial class tbInventory
    {
        public int ID { get; set; }
        public string FlowType { get; set; }
        public Nullable<int> Qty { get; set; }
        public Nullable<decimal> ItemPrice { get; set; }
        public decimal TotalItemPrice { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<System.DateTime> Accesstime { get; set; }
        public Nullable<System.Guid> UniqueID { get; set; }
        public Nullable<System.Guid> ItemGUID { get; set; }
        public string ItemName { get; set; }
        public string TransactionType { get; set; }
        public Nullable<int> CinemaID { get; set; }
    }
}
