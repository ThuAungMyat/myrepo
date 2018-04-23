using System;
using System.Collections.Generic;

namespace SampleWeb.Models
{
    public partial class tbActivityLog
    {
        public int ID { get; set; }
        public string UserId { get; set; }
        public string EventPayload { get; set; }
        public Nullable<System.DateTime> Accesstime { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    }
}
