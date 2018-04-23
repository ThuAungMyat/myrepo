using System;
using System.Collections.Generic;

namespace SampleWeb.Models
{
    public partial class tbRole
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> Accesstime { get; set; }
        public Nullable<int> Createdby { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<int> GroupID { get; set; }
        public string GroupName { get; set; }
        public Nullable<System.Guid> UniqueID { get; set; }
    }
}
