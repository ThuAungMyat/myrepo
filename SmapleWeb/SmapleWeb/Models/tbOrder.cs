using System;
using System.Collections.Generic;

namespace SampleWeb.Models
{
    public partial class tbOrder
    {
        public int ID { get; set; }
        public string StaffGUID { get; set; }
        public string StaffName { get; set; }
        public Nullable<int> CinemaId { get; set; }
        public string CinemaName { get; set; }
        public string VoucherCode { get; set; }
        public Nullable<System.DateTime> Accesstime { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<decimal> TotalPrice { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public string Status { get; set; }
        public Nullable<decimal> ServiceFees { get; set; }
        public Nullable<decimal> SubTotalPrice { get; set; }
        public Nullable<decimal> TotalTax { get; set; }
        public Nullable<bool> TaxIncluded { get; set; }
        public string Currency { get; set; }
        public Nullable<decimal> TotalDiscounts { get; set; }
        public Nullable<decimal> TotalItemPrice { get; set; }
        public string DiscountCode { get; set; }
        public string Remark { get; set; }
    }
}
