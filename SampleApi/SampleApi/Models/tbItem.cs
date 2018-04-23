using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleApi.Entities
{
    public class tbItem
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
