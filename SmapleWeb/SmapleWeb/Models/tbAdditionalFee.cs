using System;
using System.Collections.Generic;

namespace SampleWeb.Models
{
    public partial class tbAdditionalFee
    {
        public int ID { get; set; }
        public Nullable<System.Guid> UniqueID { get; set; }
        public Nullable<decimal> RetailAmount { get; set; }
        public Nullable<decimal> CycleAmount { get; set; }
        public Nullable<System.DateTime> Showtime { get; set; }
        public Nullable<int> CinemaID { get; set; }
        public Nullable<System.DateTime> Accesstime { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    }
}
