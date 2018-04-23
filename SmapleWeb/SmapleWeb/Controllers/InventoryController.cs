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
    public class InventoryController : Controller
    {
        // GET: Inventory
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> _inventoryListPartial(string itemGUID, int cinemaID)
        {
            string url = string.Format("api/Inventory/GetInventoryListByItemGUID?itemGUID={0}", itemGUID);
            List<tbInventory> result = await APIRequest<List<tbInventory>>.Get(url);
            return PartialView("_inventoryListPartial", result);
        }

        //_InventoryForm
        public async Task<ActionResult> _InventoryForm(string FormType, int ID)
        {
            tbInventory tbInventory = new tbInventory();
            if (FormType == "Add")
            {
                return PartialView("_InventoryForm", tbInventory);
            }

            else
            {
                string url = string.Format("api/Inventory/GetInventoryByID?ID={0}", ID);
                tbInventory result = await APIRequest<tbInventory>.Get(url);
                return PartialView("_InventoryForm", result);
            }

        }

        //_InsertStock
        public async Task<ActionResult> _InsertStock( int itemID)
        {
            string url = string.Format("api/Item/GetItemByID?ID={0}", itemID);
            tbItem result = await APIRequest<tbItem>.Get(url);

            return PartialView("_InventoryForm", result);
        }

        //UpSertInventory
        public async Task<ActionResult> UpSertInventory(tbInventory tbInventory)
        {

            var url = "api/Inventory/UpsertInventory";
            tbInventory result = await APIRequest<tbInventory>.Post(url, tbInventory);
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