using SampleApi.Data;
using SampleApi.Entities;
using SampleApi.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SampleApi.Controllers
{
    public class InventoryController : ApiController
    {
        #region api/Inventory/GetInventory
        /// <summary>
        /// API to get all Inventorys list.
        /// </summary>
        /// <param name="request">request</param>
        /// <returns>HttpResponseMessage</returns>
        [HttpGet]
        [Route("api/Inventory/GetInventory")]
        public HttpResponseMessage GetInventory(HttpRequestMessage request)
        {
            Context ctx = new Context();
            InventoryRepository inventoryRepo = new InventoryRepository(ctx);
            IEnumerable<tbInventory> result = inventoryRepo.GetDataSet().Where(a => a.IsDeleted != true).ToList();
            ctx.Dispose();
            return request.CreateResponse<IEnumerable<tbInventory>>(HttpStatusCode.OK, result);
        }
        #endregion

        #region api/Inventory/GetInventoryByID
        /// <summary>
        /// API to get Inventory by identity.
        /// </summary>
        /// <param name="request">request</param>
        /// <param name="ID">ID</param>
        /// <returns>HttpResponseMessage</returns>
        [HttpGet]
        [Route("api/Inventory/GetInventoryByID")]
        public HttpResponseMessage GetInventoryByID(HttpRequestMessage request, int ID)
        {
            Context ctx = new Context();
            InventoryRepository inventoryRepo = new InventoryRepository(ctx);
            tbInventory result = inventoryRepo.GetDataSet().Where(a => a.IsDeleted != true && a.ID == ID).FirstOrDefault();
            return request.CreateResponse<tbInventory>(HttpStatusCode.OK, result);
        }
        #endregion

        #region api/Inventory/UpsertInventory
        /// <summary>
        /// API to insert or update Inventory.
        /// </summary>
        /// <param name="request">request</param>
        /// <param name="tbInventory">tbInventory</param>
        /// <returns>HttpResponseMessage</returns>
        [HttpPost]
        [Route("api/Inventory/UpsertInventory")]
        public HttpResponseMessage UpsertInventory(HttpRequestMessage request, tbInventory tbInventory)
        {
            Context ctx = new Context();
            InventoryRepository inventoryRepo = new InventoryRepository(ctx);
            StockRepository stockRepo = new StockRepository(ctx);
            tbInventory UpdatedEntity = null;
            
            //if (tbInventory.ID > 0)
            //{
            //    UpdatedEntity = inventoryRepo.update(tbInventory);
            //}
            if (tbInventory.TransactionType == "2") //Transaction Type : Justifity
            {
                tbStock tbStock = stockRepo.GetDataSet().Where(a => a.IsDeleted != true && a.ItemGUID == tbInventory.ItemGUID).FirstOrDefault();
                if (tbStock.StockQty >= tbInventory.Qty)// Check the given quantity is enough or not in the stock table.
                {
                    tbInventory.FlowType = "Justify";
                    tbInventory.Accesstime = DateTime.UtcNow.ToLocalTime();
                    tbInventory.IsDeleted = false;
                    tbInventory.UniqueID = Guid.NewGuid();
                    tbInventory.TotalItemPrice = Convert.ToDecimal(tbInventory.ItemPrice * tbInventory.Qty);
                    UpdatedEntity = inventoryRepo.Add(tbInventory);

                    tbStock tbStock1= stockRepo.GetDataSet().Where(a => a.IsDeleted != true && a.ItemGUID == tbInventory.ItemGUID).FirstOrDefault();
                    tbStock1.StockQty -= tbInventory.Qty;
                    stockRepo.update(tbStock1);

                }
                else
                {
                    return request.CreateResponse<tbInventory>(HttpStatusCode.OK, UpdatedEntity); ;
                }
               
            }
            else
            {
                tbInventory.FlowType = "StockIn";
                tbInventory.Accesstime = DateTime.UtcNow.ToLocalTime();
                tbInventory.IsDeleted = false;
                tbInventory.UniqueID = Guid.NewGuid();
                tbInventory.TotalItemPrice = Convert.ToDecimal(tbInventory.ItemPrice * tbInventory.Qty);

                UpdatedEntity = inventoryRepo.Add(tbInventory);
                tbStock tbStock = stockRepo.GetDataSet().Where(a => a.IsDeleted != true && a.ItemGUID == tbInventory.ItemGUID).FirstOrDefault();
                tbStock.StockQty += tbInventory.Qty;
                stockRepo.update(tbStock);

            }

            return request.CreateResponse<tbInventory>(HttpStatusCode.OK, UpdatedEntity);
        }

        #endregion

        #region api/Inventory/GetInventoryListByItemGUID
        /// <summary>
        /// API to get all inventory list by itemGUID.
        /// </summary>
        /// <param name="request">request</param>
        /// <param name="itemGUID">itemGUID</param>
        /// <param name="CinemaID">CinemaID</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Inventory/GetInventoryListByItemGUID")]
        public HttpResponseMessage GetInventoryListByItemGUID(HttpRequestMessage request,string itemGUID)
        {

            using (var ctx = new Context())
            {
                
                //List<tbInventory> result = ctx.tbInventorys.Where(a => a.ItemGUID.ToString() == itemGUID && a.CinemaID == CinemaID && a.IsDeleted != true).ToList();
                List<tbInventory> result = ctx.tbInventorys.Where(a => a.ItemGUID.ToString() == itemGUID && a.IsDeleted != true).ToList();

                return request.CreateResponse<List<tbInventory>>(HttpStatusCode.OK, result);
            }

        }
        #endregion
    }
}