using System;
using System.Collections.Generic;

namespace SampleWeb.Models
{
    public partial class tbCinemaLogin
    {
        public int ID { get; set; }
        public Nullable<int> StaffId { get; set; }
        public Nullable<System.DateTime> LoginTime { get; set; }
        public Nullable<System.DateTime> LogoutTime { get; set; }
        public string Role { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public string CinemaName { get; set; }
        public Nullable<int> CinemaId { get; set; }
        public string StaffName { get; set; }
        public Nullable<int> GroupId { get; set; }
        public string GroupName { get; set; }
        public Nullable<int> RoleID { get; set; }
    }
}
