using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleWeb.Entities
{
    public class Artist
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Nullable<int> Age { get; set; }
        public string Description { get; set; }
        public Boolean? IsDeleted { get; set; }
        public DateTime? Accesstime { get; set; }
    }
}