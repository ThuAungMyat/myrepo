using System;
using System.Collections.Generic;

namespace SampleWeb.Models
{
    public partial class tbMPUPaymentLog
    {
        public int ID { get; set; }
        public string merchantID { get; set; }
        public string respCode { get; set; }
        public string pan { get; set; }
        public string amount { get; set; }
        public string invoiceNo { get; set; }
        public string tranRef { get; set; }
        public string approvalCode { get; set; }
        public string dateTime { get; set; }
        public string status { get; set; }
        public string failReason { get; set; }
        public string userDefined1 { get; set; }
        public string userDefined2 { get; set; }
        public string userDefined3 { get; set; }
        public string hashValue { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    }
}
