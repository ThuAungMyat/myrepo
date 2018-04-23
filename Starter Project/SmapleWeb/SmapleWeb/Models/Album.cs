using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleWeb.Entities
{
    public class Album
    {
        public int ID { get; set; }
        public string AlbumName { get; set; }
        public string Description { get; set; }
        public Decimal? Price { get; set; }
        public Boolean? IsDeleted { get; set; }
        public int? ArtistID { get; set; }
    }
}