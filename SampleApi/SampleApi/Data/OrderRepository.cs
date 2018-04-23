using SampleApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleApi.Data
{
    public class OrderRepository : DataRepositoryBase<tbOrder>
    {
        public Context _context;
        public OrderRepository(Context context)
        {
            _context = context;
        }

        public OrderRepository()
        {

        }
        protected override tbOrder AddEntity(Context entityContext, tbOrder entity)
        {
            return entityContext.tbOrders.Add(entity);
        }
        protected override tbOrder UpdateEntity(Context entityContext, tbOrder entity)
        {
            return entityContext.tbOrders.FirstOrDefault(a => a.ID == entity.ID);
        }
        protected override IQueryable<tbOrder> GetEntities(Context entityContext)
        {
            return entityContext.tbOrders;
        }
        protected override IQueryable<tbOrder> GetQueryable()
        {
            return _context.tbOrders;
        }
        protected override tbOrder GetEntity(Context entityContext, int id)
        {
            return entityContext.tbOrders.FirstOrDefault(a => a.ID == id);
        }

    }
}