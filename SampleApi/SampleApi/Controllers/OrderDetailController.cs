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
    public class OrderDetailController : ApiController
    {
        #region api/OrderDetail/GetOrderDetail
        /// <summary>
        /// API to get all order details list.
        /// </summary>
        /// <param name="request">request</param>
        /// <returns>HttpResponseMessage</returns>
        [HttpGet]
        [Route("api/OrderDetail/GetOrderDetail")]
        public HttpResponseMessage GetOrderDetail(HttpRequestMessage request)
        {
            Context ctx = new Context();
            OrderDetailRepository orderDetailRepo = new OrderDetailRepository(ctx);
            IEnumerable<tbOrderDetail> result = orderDetailRepo.GetDataSet().Where(a => a.IsDeleted != true).ToList();
            ctx.Dispose();
            return request.CreateResponse<IEnumerable<tbOrderDetail>>(HttpStatusCode.OK, result);
        }
        #endregion

        #region api/OrderDetail/GetOrderDetailByID
        /// <summary>
        /// API to get order detail by identity.
        /// </summary>
        /// <param name="request">request</param>
        /// <param name="ID">ID</param>
        /// <returns>HttpResponseMessage</returns>
        [HttpGet]
        [Route("api/OrderDetail/GetOrderDetailByID")]
        public HttpResponseMessage GetOrderDetailByID(HttpRequestMessage request, int ID)
        {
            OrderDetailRepository orderDetailRepo = new OrderDetailRepository();
            tbOrderDetail result = orderDetailRepo.GetDataSet().Where(a => a.IsDeleted != true && a.ID == ID).FirstOrDefault();
            return request.CreateResponse<tbOrderDetail>(HttpStatusCode.OK, result);
        }
        #endregion

        #region api/OrderDetail/UpsertOrderDetail
        /// <summary>
        /// API to insert or update order detail.
        /// </summary>
        /// <param name="request">request</param>
        /// <param name="tbOrderDetail">tbOrderDetail</param>
        /// <returns>HttpResponseMessage</returns>
        [HttpGet]
        [Route("api/OrderDetail/UpsertOrderDetail")]
        public HttpResponseMessage UpsertOrderDetail(HttpRequestMessage request, string items)
        {
            #region Instances

            Context ctx = new Context();

            ItemRepository itemRepo = new ItemRepository(ctx);
            StockRepository stockRepo = new StockRepository(ctx);
            OrderRepository orderRepo = new OrderRepository(ctx);
            OrderDetailRepository orderDetailRepo = new OrderDetailRepository(ctx);
            InventoryRepository inventoryRepo = new InventoryRepository(ctx);
          
            tbItem tbItem = new tbItem();
            tbStock tbStock = new tbStock();
            tbInventory tbInventory = new tbInventory();
            tbOrder tbOrder = new tbOrder();
            tbOrderDetail tbOrderDetail = new tbOrderDetail();
            tbOrder UpdatedOrder = null;
            tbOrderDetail UpdatedEntity = null;
            decimal totalPrice = 0;
            string voucherCode = Guid.NewGuid().ToString();

            #endregion

            #region insert order table

            tbOrder.StaffGUID = "Default";
            tbOrder.StaffName = "Default";
            tbOrder.CinemaId = 1;
            tbOrder.CinemaName = "";
            tbOrder.VoucherCode = voucherCode;
            tbOrder.Accesstime = DateTime.UtcNow.ToLocalTime();
            tbOrder.IsDeleted = false;
            tbOrder.TotalPrice = totalPrice;
            tbOrder.CreatedAt = DateTime.UtcNow.ToLocalTime();
            tbOrder.Status = "Default";
            tbOrder.ServiceFees = 0;
            tbOrder.SubTotalPrice = tbOrder.TotalPrice;
            tbOrder.TotalTax = 0;
            tbOrder.TaxIncluded = false;
            tbOrder.Currency = "";
            tbOrder.TotalDiscounts = 0;
            tbOrder.TotalItemPrice = tbOrder.TotalPrice;
            tbOrder.DiscountCode = "";
            tbOrder.Remark = "";
            UpdatedOrder = orderRepo.Add(tbOrder);

            #endregion

            List<string> itemList = items.Split(',').ToList();
            foreach (string item in itemList)
            {              
                string[] idVal = item.Split('|').ToArray();
                string itemGUID = idVal[0];
                int qty = Convert.ToInt32(idVal[1]);
                tbItem = itemRepo.GetDataSet().Where(a => a.IsDeleted != true && a.UniqueID.ToString() == itemGUID).FirstOrDefault();

                //if(tbStock.StockQty>=qty)
                //{ }
                #region Add order detail.

                tbOrderDetail.ItemID = tbItem.ID;
                tbOrderDetail.ItemName = tbItem.Item;
                tbOrderDetail.ItemPrice = tbItem.SellingPrice;
                tbOrderDetail.ItemQty = qty;
                tbOrderDetail.TotalPrice = tbOrderDetail.ItemPrice * qty;
                totalPrice += Convert.ToDecimal(tbOrderDetail.TotalPrice);
                tbOrderDetail.VoucherCode = voucherCode;
                tbOrderDetail.OrderID = UpdatedOrder.ID;
                tbOrderDetail.CinemaID = tbOrder.CinemaId;
                tbOrderDetail.CinemaName = tbOrder.CinemaName;
                tbOrderDetail.IsDeleted = false;
                UpdatedEntity= orderDetailRepo.Add(tbOrderDetail);

                #endregion

                #region update stock table.

                tbStock = stockRepo.GetDataSet().Where(s => s.IsDeleted != true && s.ItemGUID.ToString() == itemGUID && s.CinemaID == tbOrder.CinemaId).FirstOrDefault();
                tbStock.StockQty = tbStock.StockQty - qty;
                tbStock.Accesstime = DateTime.UtcNow.ToLocalTime();
                stockRepo.update(tbStock);

                #endregion

                #region update inventory table.

                tbInventory.FlowType = "StockOut";
                tbInventory.ItemPrice = tbItem.SellingPrice;
                tbInventory.TotalItemPrice = totalPrice;
                tbInventory.IsDeleted = false;
                tbInventory.Accesstime = DateTime.UtcNow.ToLocalTime();
                tbInventory.UniqueID = Guid.NewGuid();
                tbInventory.ItemGUID = tbItem.UniqueID;
                tbInventory.ItemName = tbItem.Item;
                tbInventory.TransactionType = "3"; //TransactionType:3 (StockOut)
                tbInventory.CinemaID = tbOrder.CinemaId;
                tbInventory.Qty = qty;
                inventoryRepo.Add(tbInventory);

                #endregion
            }

            #region update total price to order table

            tbOrder = orderRepo.GetDataSet().Where(x => x.IsDeleted != true && x.VoucherCode == voucherCode).FirstOrDefault();
            tbOrder.TotalPrice = totalPrice;
            tbOrder.TotalItemPrice = totalPrice;
            orderRepo.update(tbOrder);

            #endregion

            return request.CreateResponse<tbOrderDetail>(HttpStatusCode.OK, UpdatedEntity);
        }

        #endregion

        #region api/OrderDetail/GetOrderDetailByVoucherCode
        /// <summary>
        /// API to get Order Detail by voucher code.
        /// </summary>
        /// <param name="request">request</param>
        /// <param name="voucherCode">voucherCode</param>
        /// <returns>HttpResponseMessage</returns>
        [HttpGet]
        [Route("api/OrderDetail/GetOrderDetailByVoucherCode")]
        public HttpResponseMessage GetOrderDetailByVoucherCode(HttpRequestMessage request, string voucherCode)
        {
            Context ctx = new Context();
            OrderDetailRepository orderDetailRepo = new OrderDetailRepository(ctx);
            List<tbOrderDetail> result = orderDetailRepo.GetDataSet().Where(a => a.IsDeleted != true && a.VoucherCode == voucherCode).ToList();
            return request.CreateResponse<List<tbOrderDetail>>(HttpStatusCode.OK, result);
        }
        #endregion
    }
}