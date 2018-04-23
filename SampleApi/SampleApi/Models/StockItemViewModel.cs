using SampleApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleApi.Models
{
    public class StockItemViewModel
    {
        public tbStock tbStock { get; set; }
        public tbItem tbItem { get; set; }
    }
}