using System;
using System.Collections.Generic;

namespace SampleWeb.Models
{
    public partial class tbMovie
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Synopsis { get; set; }
        public string Review { get; set; }
        public string RunTime { get; set; }
        public Nullable<decimal> Rating { get; set; }
        public string Director { get; set; }
        public string Cast { get; set; }
        public string Type { get; set; }
        public string Production { get; set; }
        public string Distribution { get; set; }
        public string Budget { get; set; }
        public string BoxOffice { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<bool> IsUpComing { get; set; }
        public string CoverImage { get; set; }
        public string Trailer { get; set; }
        public string Remark { get; set; }
        public Nullable<decimal> Metascore { get; set; }
        public Nullable<System.DateTime> ReleaseDate { get; set; }
        public Nullable<bool> IsShowing { get; set; }
        public Nullable<int> TheatreId { get; set; }
        public string TheatreName { get; set; }
        public string Discriminator { get; set; }
        public string Image { get; set; }
        public Nullable<System.DateTime> Accesstime { get; set; }
        public Nullable<System.Guid> UniqueID { get; set; }
        public string ImageUrlRoot { get; set; }
        public Nullable<int> GroupID { get; set; }
        public Nullable<bool> AvailableInBot { get; set; }
    }
}
