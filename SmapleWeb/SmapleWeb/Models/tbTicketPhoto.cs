using System;
using System.Collections.Generic;

namespace SampleWeb.Models
{
    public partial class tbTicketPhoto
    {
        public int ID { get; set; }
        public string GroupName { get; set; }
        public Nullable<int> GroupID { get; set; }
        public string Image { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<System.DateTime> Accesstime { get; set; }
        public string UploadedBy { get; set; }
        public string PhotoType { get; set; }
    }
}
