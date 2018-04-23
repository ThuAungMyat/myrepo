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
    public class OrderController : ApiController
    {
        #region api/Order/GetOrder
        /// <summary>
        /// API to get all Orders list.
        /// </summary>
        /// <param name="request">request</param>
        /// <returns>HttpResponseMessage</returns>
        [HttpGet]
        [Route("api/Order/GetOrder")]
        public HttpResponseMessage GetOrder(HttpRequestMessage request)
        {
            Context ctx = new Context();
            OrderRepository orderRepo = new OrderRepository(ctx);
            IEnumerable<tbOrder> result = orderRepo.GetDataSet().Where(a => a.IsDeleted != true).ToList();
            ctx.Dispose();
            return request.CreateResponse<IEnumerable<tbOrder>>(HttpStatusCode.OK, result);
        }
        #endregion

        #region api/Order/GetOrderByID
        /// <summary>
        /// API to get Order by identity.
        /// </summary>
        /// <param name="request">request</param>
        /// <param name="ID">ID</param>
        /// <returns>HttpResponseMessage</returns>
        [HttpGet]
        [Route("api/Order/GetOrderByID")]
        public HttpResponseMessage GetOrderByID(HttpRequestMessage request, int ID)
        {
            Context ctx = new Context();
            OrderRepository orderRepo = new OrderRepository(ctx);
            tbOrder result = orderRepo.GetDataSet().Where(a => a.IsDeleted != true && a.ID == ID).FirstOrDefault();
            return request.CreateResponse<tbOrder>(HttpStatusCode.OK, result);
        }
        #endregion


        #region api/Order/GetOrderByID
        /// <summary>
        /// API to get Order by identity.
        /// </summary>
        /// <param name="request">request</param>
        /// <param name="cinemaId">cinemaId</param>
        /// <returns>HttpResponseMessage</returns>
        [HttpGet]
        [Route("api/Order/GetOrderByCinemaId")]
        public HttpResponseMessage GetOrderByCinemaId(HttpRequestMessage request, int cinemaId)
        {
            Context ctx = new Context();
            OrderRepository orderRepo = new OrderRepository(ctx);
            List<tbOrder> result = orderRepo.GetDataSet().Where(a => a.IsDeleted != true && a.CinemaId == cinemaId).ToList() ;
            return request.CreateResponse<List<tbOrder>>(HttpStatusCode.OK, result);
        }
        #endregion

        #region api/Order/UpsertOrder
        /// <summary>
        /// API to insert or update order.
        /// </summary>
        /// <param name="request">request</param>
        /// <param name="tbOrder">tbOrder</param>
        /// <returns>HttpResponseMessage</returns>
        [HttpPost]
        [Route("api/Order/UpsertOrder")]
        public HttpResponseMessage UpsertOrder(HttpRequestMessage request, tbOrder tbOrder)
        {
            OrderRepository orderRepo = new OrderRepository();
            tbOrder UpdatedEntity = null;
            if (tbOrder.ID > 0)
            {
                UpdatedEntity = orderRepo.update(tbOrder);
            }
            else
            {
                UpdatedEntity = orderRepo.Add(tbOrder);
            }

            return request.CreateResponse<tbOrder>(HttpStatusCode.OK, UpdatedEntity);
        }

        #endregion
    }
}