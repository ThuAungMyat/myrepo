using System;
using System.Collections.Generic;

namespace SampleWeb.Models
{
    public partial class tbCinema
    {
        public int ID { get; set; }
        public Nullable<int> CinemaID { get; set; }
        public string CinemaName { get; set; }
        public Nullable<int> TheatreID { get; set; }
        public string TheatreName { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public Nullable<decimal> Latitude { get; set; }
        public Nullable<decimal> Logitude { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<System.DateTime> Accesstime { get; set; }
        public string FacebookPage { get; set; }
        public string Website { get; set; }
        public string State { get; set; }
        public string Township { get; set; }
        public Nullable<decimal> Rating { get; set; }
        public string Image { get; set; }
        public string SeatPlan { get; set; }
        public string Showtime { get; set; }
        public Nullable<int> GroupID { get; set; }
        public string GroupTitle { get; set; }
        public string SeatPlanUrl { get; set; }
        public string ImageUrl { get; set; }
        public Nullable<System.Guid> UniqueID { get; set; }
        public Nullable<bool> IsSyncedEnabled { get; set; }
    }
}
