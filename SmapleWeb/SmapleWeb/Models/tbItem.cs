using System;
using System.Collections.Generic;

namespace SampleWeb.Models
{
    public partial class tbItem
    {
        public int ID { get; set; }
        public string Item { get; set; }
        public string Code { get; set; }
        public Nullable<decimal> BuyingPrice { get; set; }
        public Nullable<decimal> SellingPrice { get; set; }
        public string Description { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<System.DateTime> Accesstime { get; set; }
        public Nullable<System.Guid> UniqueID { get; set; }
    }
}
