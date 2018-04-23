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
    public class StockController : ApiController
    {
        #region api/Stock/GetStock
        /// <summary>
        /// API to get all stocks list.
        /// </summary>
        /// <param name="request">request</param>
        /// <returns>HttpResponseMessage</returns>
        [HttpGet]
        [Route("api/Stock/GetStock")]
        public HttpResponseMessage GetStock(HttpRequestMessage request)
        {
            Context ctx = new Context();
            StockRepository stockRepo = new StockRepository(ctx);
            IEnumerable<tbStock> result = stockRepo.GetDataSet().Where(a => a.IsDeleted != true).ToList();
            ctx.Dispose();
            return request.CreateResponse<IEnumerable<tbStock>>(HttpStatusCode.OK, result);
        }
        #endregion

        #region api/Stock/GetStockByID
        /// <summary>
        /// API to get stock by identity.
        /// </summary>
        /// <param name="request">request</param>
        /// <param name="ID">ID</param>
        /// <returns>HttpResponseMessage</returns>
        [HttpGet]
        [Route("api/Stock/GetStockByID")]
        public HttpResponseMessage GetStockByID(HttpRequestMessage request, int ID)
        {
            StockRepository stockRepo = new StockRepository();
            tbStock result = stockRepo.GetDataSet().Where(a => a.IsDeleted != true && a.ID == ID).FirstOrDefault();
            return request.CreateResponse<tbStock>(HttpStatusCode.OK, result);
        }
        #endregion

        #region api/Stock/UpsertStock
        /// <summary>
        /// API to insert or update stock.
        /// </summary>
        /// <param name="request">request</param>
        /// <param name="tbStock">tbStock</param>
        /// <returns>HttpResponseMessage</returns>
        [HttpPost]
        [Route("api/Stock/UpsertStock")]
        public HttpResponseMessage UpsertStock(HttpRequestMessage request, tbStock tbStock)
        {
            StockRepository stockRepo = new StockRepository();
            tbStock UpdatedEntity = null;
            if (tbStock.ID > 0)
            {
                UpdatedEntity = stockRepo.update(tbStock);
            }
            else
            {
                tbStock.IsDeleted = false;
                tbStock.Accesstime = DateTime.UtcNow.ToLocalTime();

                UpdatedEntity = stockRepo.Add(tbStock);
            }

            return request.CreateResponse<tbStock>(HttpStatusCode.OK, UpdatedEntity);
        }

        #endregion
    }
}