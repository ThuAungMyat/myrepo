using DAOWEB.ApiRepo;
using SampleWeb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace SampleWeb.Controllers
{
    public class SaleController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}