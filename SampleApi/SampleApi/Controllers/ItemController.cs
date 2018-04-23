using SampleApi.Data;
using SampleApi.Entities;
using SampleApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SampleApi.Controllers
{
    public class ItemController : ApiController
    {
        #region api/Item/GetItem
        /// <summary>
        /// API to get all items list.
        /// </summary>
        /// <param name="request">request</param>
        /// <returns>HttpResponseMessage</returns>
        [HttpGet]
        [Route("api/Item/GetItem")]
        public HttpResponseMessage GetItem(HttpRequestMessage request, int CinemaID=1)
        {
          
            using(var ctx = new Context())
            {
                List<StockItemViewModel> result = (from s in ctx.tbStocks.Where(a => a.IsDeleted != true && a.CinemaID == CinemaID)
                                                    join i in ctx.tbItems.Where(a => a.IsDeleted != true) on s.ItemGUID equals i.UniqueID
                                                    select new StockItemViewModel()
                                                    {
                                                        tbStock = s,
                                                        tbItem = i,
                                                    }).ToList();
                return request.CreateResponse<List<StockItemViewModel>>(HttpStatusCode.OK, result);
            }
           
        }
        #endregion

        #region api/Item/GetItemByID
        /// <summary>
        /// API to get item by identity.
        /// </summary>
        /// <param name="request">request</param>
        /// <param name="ID">ID</param>
        /// <returns>HttpResponseMessage</returns>
        [HttpGet]
        [Route("api/Item/GetItemByID")]
        public HttpResponseMessage GetItemByID(HttpRequestMessage request, int ID)
        {
            Context ctx = new Context();
            ItemRepository itemRepo = new ItemRepository(ctx);
            tbItem result = itemRepo.GetDataSet().Where(a => a.IsDeleted != true && a.ID == ID).FirstOrDefault();
            return request.CreateResponse<tbItem>(HttpStatusCode.OK, result);

        }
        #endregion

        #region api/Item/SearchItemByItemCode
        /// <summary>
        /// API to get all item list by itemCode.
        /// </summary>
        /// <param name="request">request</param>
        /// <param name="itemCode">itemCode</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Item/SearchItemByItemCode")]
        public HttpResponseMessage SearchItemByItemCode(HttpRequestMessage request, string code,int cinemaID)
        {
            using (var ctx = new Context())
            {
                List<StockItemViewModel> result = (from s in ctx.tbStocks.Where(a => a.IsDeleted != true && a.CinemaID == cinemaID)
                                                   join i in ctx.tbItems.Where(a => a.IsDeleted != true && a.Code.StartsWith(code)) on s.ItemGUID equals i.UniqueID
                                                   select new StockItemViewModel()
                                                   {
                                                       tbStock = s,
                                                       tbItem = i,
                                                   }).ToList();
                return request.CreateResponse<List<StockItemViewModel>>(HttpStatusCode.OK, result);
            }
        }
        #endregion

        #region api/Item/UpsertItem
        /// <summary>
        /// API to insert or update item.
        /// </summary>
        /// <param name="request">request</param>
        /// <param name="tbItem">tbItem</param>
        /// <returns>HttpResponseMessage</returns>
        [HttpPost]
        [Route("api/Item/UpsertItem")]
        public HttpResponseMessage UpsertItem(HttpRequestMessage request, tbItem tbItem)
        {
            ItemRepository itemRepo = new ItemRepository();
            StockRepository stockRepo = new StockRepository();
            tbItem UpdatedEntity = null;
            tbStock tbstock = new tbStock();
            if (tbItem.ID > 0)
            {
                UpdatedEntity = itemRepo.update(tbItem);
            }
            else
            {
                tbItem.UniqueID = Guid.NewGuid();
                tbItem.IsDeleted = false;
                tbItem.Accesstime = DateTime.UtcNow.ToLocalTime();
                UpdatedEntity = itemRepo.Add(tbItem);

                tbstock.ItemGUID = tbItem.UniqueID;
                tbstock.CinemaID = 0;
                tbstock.IsDeleted = false;
                tbstock.Accesstime = DateTime.UtcNow.ToLocalTime();
                tbstock.StockStatus = "Stock Register";
                tbstock.StockQty = 0;
                tbstock.ThresholdQty = 0;
                stockRepo.Add(tbstock);
            }

            return request.CreateResponse<tbItem>(HttpStatusCode.OK, UpdatedEntity);
        }

        #endregion
    }
}