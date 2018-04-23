using System;
using System.Collections.Generic;

namespace SampleWeb.Models
{
    public partial class tbServerRoute
    {
        public int ID { get; set; }
        public string RouteAddress { get; set; }
        public Nullable<int> CinemaID { get; set; }
        public string CinemaName { get; set; }
        public Nullable<int> GroupID { get; set; }
        public string GroupName { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<System.DateTime> Accesstime { get; set; }
    }
}
