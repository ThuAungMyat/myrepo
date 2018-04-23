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
    public class ItemController : Controller
    {
        // GET: Item
        public ActionResult Index()
        {
            return View();
        }

        // GET: Item
        public ActionResult ItemRegister()
        {
            //return View("Item");

            ViewBag.data1 = "asd";
            return View("Item");
        }


        public async Task<ActionResult> _itemListPartial()
        {
            string url = string.Format("api/Item/GetItem");
            List<StockItemViewModel> result = await APIRequest<List<StockItemViewModel>>.Get(url);
            return PartialView("_itemListPartial", result);
        }

        //_ItemForm
        public async Task<ActionResult> _ItemForm(string FormType, int ID)
        {
            tbItem tbItem = new tbItem();
            if (FormType == "Add")
            {
                return PartialView("_ItemForm", tbItem);
            }

            else
            {
                string url = string.Format("api/Item/GetItemByID?ID={0}", ID);
                tbItem result = await APIRequest<tbItem>.Get(url);
                return PartialView("_ItemForm", result);
            }

        }

        //_GetItemForStock
        public async Task<ActionResult> _GetItemForStock(int ID)
        {
                string url = string.Format("api/Item/GetItemByID?ID={0}", ID);
                tbItem result = await APIRequest<tbItem>.Get(url);
                return Json(result, JsonRequestBehavior.AllowGet);
        }

        //_GetItemForSearchForm
        public async Task<ActionResult> _ItemSearchForm(string code,int cinemaID)
        {
            string url = string.Format("api/Item/SearchItemByItemCode?code={0}&&cinemaID={1}", code,cinemaID);
            List<StockItemViewModel> searchItemList = await APIRequest<List<StockItemViewModel>>.Get(url);
            return PartialView("_searchItemListPartial", searchItemList);
        }


        //UpSertItem
        public async Task<ActionResult> UpSertItem(tbItem tbItem)
        {

            var url = "api/Item/UpsertItem";
            tbItem result = await APIRequest<tbItem>.Post(url, tbItem);
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