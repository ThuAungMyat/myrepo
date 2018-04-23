using SampleApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleApi.Data
{
    public class OrderDetailRepository : DataRepositoryBase<tbOrderDetail>
    {
        public Context _context;
        public OrderDetailRepository(Context context)
        {
            _context = context;
        }

        public OrderDetailRepository()
        {

        }
        protected override tbOrderDetail AddEntity(Context entityContext, tbOrderDetail entity)
        {
            return entityContext.tbOrderDetails.Add(entity);
        }
        protected override tbOrderDetail UpdateEntity(Context entityContext, tbOrderDetail entity)
        {
            return entityContext.tbOrderDetails.FirstOrDefault(a => a.ID == entity.ID);
        }
        protected override IQueryable<tbOrderDetail> GetEntities(Context entityContext)
        {
            return entityContext.tbOrderDetails;
        }
        protected override IQueryable<tbOrderDetail> GetQueryable()
        {
            return _context.tbOrderDetails;
        }
        protected override tbOrderDetail GetEntity(Context entityContext, int id)
        {
            return entityContext.tbOrderDetails.FirstOrDefault(a => a.ID == id);
        }

    }
}