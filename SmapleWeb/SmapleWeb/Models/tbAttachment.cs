using System;
using System.Collections.Generic;

namespace SampleWeb.Models
{
    public partial class tbAttachment
    {
        public int ID { get; set; }
        public string AttachmentID { get; set; }
        public Nullable<int> FileID { get; set; }
        public Nullable<System.DateTime> Accesstime { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public string RequestType { get; set; }
        public string FormID { get; set; }
        public string UploadedBy { get; set; }
    }
}
