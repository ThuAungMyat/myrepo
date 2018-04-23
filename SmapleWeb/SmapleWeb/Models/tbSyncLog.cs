using System;
using System.Collections.Generic;

namespace SampleWeb.Models
{
    public partial class tbSyncLog
    {
        public int ID { get; set; }
        public string TableName { get; set; }
        public Nullable<int> RowId { get; set; }
        public Nullable<System.DateTime> CreatedTime { get; set; }
        public Nullable<int> TheatreId { get; set; }
        public Nullable<int> CinemaId { get; set; }
        public Nullable<System.Guid> RowGuid { get; set; }
        public string ClientID { get; set; }
        public Nullable<System.Guid> SyncTaskID { get; set; }
    }
}
