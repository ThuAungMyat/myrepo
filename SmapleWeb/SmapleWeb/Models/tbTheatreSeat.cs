using System;
using System.Collections.Generic;

namespace SampleWeb.Models
{
    public partial class tbTheatreSeat
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public string Number { get; set; }
        public Nullable<decimal> TicketFees { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<System.DateTime> Accesstime { get; set; }
        public Nullable<int> TheatreID { get; set; }
        public string TheatreName { get; set; }
        public Nullable<int> CinemaID { get; set; }
        public string CinemaName { get; set; }
        public Nullable<bool> IsAvailable { get; set; }
        public Nullable<decimal> ServiceFees { get; set; }
        public Nullable<decimal> ConvenientFees { get; set; }
        public Nullable<int> GroupID { get; set; }
        public string GroupName { get; set; }
        public Nullable<decimal> ExtraCharge { get; set; }
    }
}