using System;
using System.Collections.Generic;

namespace SampleWeb.Models
{
    public partial class tbSyncProgress
    {
        public int ID { get; set; }
        public Nullable<System.Guid> TaskID { get; set; }
        public Nullable<int> Progress { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> Accesstime { get; set; }
    }
}
