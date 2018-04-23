using System;
using System.Collections.Generic;

namespace SampleWeb.Models
{
    public partial class tbPermission
    {
        public int ID { get; set; }
        public string ActionName { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<System.DateTime> Accesstime { get; set; }
        public string Description { get; set; }
        public string HelpImage { get; set; }
        public Nullable<System.Guid> UniqueID { get; set; }
    }
}
