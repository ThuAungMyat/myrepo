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
    public class OrderDetailController : Controller
    {
        // GET: OrderDetail
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> _orderDetailListPartial()
        {
            string url = string.Format("api/OrderDetail/GetOrderDetail");
            IEnumerable<tbOrderDetail> result = await APIRequest<IEnumerable<tbOrderDetail>>.Get(url);
            return PartialView("_orderDetailListPartial", result);
        }

        //_OrderDetailForm
        public async Task<ActionResult> _OrderDetailForm(string FormType, int ID)
        {
            tbOrderDetail tbOrderDetail = new tbOrderDetail();
            if (FormType == "Add")
            {
                return PartialView("_OrderDetailForm", tbOrderDetail);
            }

            else
            {
                string url = string.Format("api/OrderDetail/GetOrderDetailByID?ID={0}", ID);
                tbOrderDetail result = await APIRequest<tbOrderDetail>.Get(url);
                return PartialView("_OrderDetailForm", result);
            }

        }

        //UpSertOrderDetail
        public async Task<ActionResult> UpSertOrderDetail(string items)
        {
            string url = string.Format("api/OrderDetail/UpsertOrderDetail?items={0}", items);
            tbOrderDetail result = await APIRequest<tbOrderDetail>.Get(url);
            return PartialView("_OrderDetailForm", result);
        }


        public async Task<ActionResult> _orderDetailListPartialByVoucherCode(string voucherCode)
        {
            string url = string.Format("api/OrderDetail/GetOrderDetailByVoucherCode?voucherCode={0}", voucherCode);
            List<tbOrderDetail> result = await APIRequest<List<tbOrderDetail>>.Get(url);
            return PartialView("_orderDetailListPartial", result);
        }

    }
}