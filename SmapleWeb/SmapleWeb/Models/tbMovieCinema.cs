using System;
using System.Collections.Generic;

namespace SampleWeb.Models
{
    public partial class tbMovieCinema
    {
        public int ID { get; set; }
        public Nullable<int> MovieID { get; set; }
        public string MovieTitle { get; set; }
        public Nullable<int> CinemaID { get; set; }
        public string CinemaName { get; set; }
        public Nullable<int> TheatreID { get; set; }
        public string TheatreName { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<System.DateTime> Accesstime { get; set; }
        public Nullable<System.DateTime> ShowDateFrom { get; set; }
        public Nullable<System.DateTime> ShowDateTo { get; set; }
        public string ShowTime { get; set; }
        public Nullable<System.Guid> UniqueID { get; set; }
        public Nullable<System.Guid> MovieGUID { get; set; }
    }
}
