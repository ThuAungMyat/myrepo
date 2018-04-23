using System;
using System.Collections.Generic;

namespace SampleWeb.Models
{
    public partial class tbUser
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<System.DateTime> Accesstime { get; set; }
        public string PhotoUrl { get; set; }
        public string UserId { get; set; }
    }
}
