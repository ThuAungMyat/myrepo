using System;
using System.Collections.Generic;

namespace SampleWeb.Models
{
    public partial class tbPaymentCode
    {
        public string Code { get; set; }
        public Nullable<bool> IsRedeemed { get; set; }
        public string Type { get; set; }
        public Nullable<System.DateTime> Accesstime { get; set; }
        public string VoucherCode { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<System.DateTime> ValidFrom { get; set; }
        public int ID { get; set; }
        public string MerchantName { get; set; }
        public Nullable<System.DateTime> GeneratedAt { get; set; }
        public string ShopCode { get; set; }
        public Nullable<System.DateTime> RedeemedAt { get; set; }
        public Nullable<decimal> TotalFees { get; set; }
        public Nullable<decimal> Tax { get; set; }
        public string UserId { get; set; }
        public string MerchantCode { get; set; }
        public string Description { get; set; }
        public Nullable<int> GroupID { get; set; }
        public string GroupName { get; set; }
        public Nullable<System.Guid> UniqueID { get; set; }
    }
}
