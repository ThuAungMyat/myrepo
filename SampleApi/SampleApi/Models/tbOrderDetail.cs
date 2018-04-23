using System;
using System.Collections.Generic;

namespace SampleApi.Entities
{
    public partial class tbOrderDetail
    {
        public int ID { get; set; }
        public Nullable<int> ItemID { get; set; }
        public string ItemName { get; set; }
        public Nullable<decimal> ItemPrice { get; set; }
        public Nullable<int> ItemQty { get; set; }
        public Nullable<decimal> TotalPrice { get; set; }
        public string VoucherCode { get; set; }
        public Nullable<int> OrderID { get; set; }
        public Nullable<int> CinemaID { get; set; }
        public string CinemaName { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    }
}
