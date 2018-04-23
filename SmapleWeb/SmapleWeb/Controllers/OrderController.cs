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
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> _orderListPartial()
        {
            string url = string.Format("api/Order/GetOrder");
            IEnumerable<tbOrder> result = await APIRequest<IEnumerable<tbOrder>>.Get(url);
            return PartialView("_orderListPartial", result);
        }

        //_OrderForm
        public async Task<ActionResult> _OrderForm(string FormType, int ID)
        {
            tbOrder tbOrder = new tbOrder();
            if (FormType == "Add")
            {
                return PartialView("_OrderForm", tbOrder);
            }

            else
            {
                string url = string.Format("api/Order/GetOrderByID?ID={0}", ID);
                tbOrder result = await APIRequest<tbOrder>.Get(url);
                return PartialView("_OrderForm", result);
            }

        }

        //UpSertOrder
        public async Task<ActionResult> UpSertOrder(tbOrder tbOrder)
        {

            var url = "api/Order/UpsertOrder";
            tbOrder result = await APIRequest<tbOrder>.Post(url, tbOrder);
            if (result != null)
            {
                return Json("Success", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Fail", JsonRequestBehavior.AllowGet);
            }
        }

        public async Task<ActionResult> _orderListPartialByCinemaId(int cinemaID)
        {
            string url = string.Format("/api/Order/GetOrderByCinemaId?cinemaId={0}", cinemaID);
            List<tbOrder> orderList = await APIRequest<List<tbOrder>>.Get(url);
            return PartialView("_orderListPartial", orderList);
        }
    }
}