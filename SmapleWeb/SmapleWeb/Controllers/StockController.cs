using DAOWEB.ApiRepo;
using SampleWeb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using SampleWeb.Models;


namespace SampleWeb.Controllers
{
    public class StockController : Controller
    {
        // GET: Stock
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> _stockListPartial()
        {
            string url = string.Format("api/Stock/GetStock");
            IEnumerable<tbStock> result = await APIRequest<IEnumerable<tbStock>>.Get(url);
            return PartialView("_stockListPartial", result);
        }

        //_StockForm
        public async Task<ActionResult> _StockForm(string FormType, int ID)
        {
            tbStock tbStock = new tbStock();
            if (FormType == "Add")
            {
                return PartialView("_StockForm", tbStock);
            }

            else
            {
                string url = string.Format("api/Stock/GetStockByID?ID={0}", ID);
                tbStock result = await APIRequest<tbStock>.Get(url);
                return PartialView("_StockForm", result);
            }

        }

        //UpSertStock
        public async Task<ActionResult> UpSertStock(tbStock tbStock)
        {

            var url = "api/Stock/UpsertStock";
            tbStock result = await APIRequest<tbStock>.Post(url, tbStock);
            if (result != null)
            {
                return Json("Success", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Fail", JsonRequestBehavior.AllowGet);
            }
        }
    }
}