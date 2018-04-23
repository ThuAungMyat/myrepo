using SampleApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleApi.Data
{
    public class ItemRepository : DataRepositoryBase<tbItem>
    {
        public Context _context;
        public ItemRepository(Context context)
        {
            _context = context;
        }

        public ItemRepository()
        {

        }
        protected override tbItem AddEntity(Context entityContext, tbItem entity)
        {
            return entityContext.tbItems.Add(entity);
        }
        protected override tbItem UpdateEntity(Context entityContext, tbItem entity)
        {
            return entityContext.tbItems.FirstOrDefault(a => a.ID == entity.ID);
        }
        protected override IQueryable<tbItem> GetEntities(Context entityContext)
        {
            return entityContext.tbItems;
        }
        protected override IQueryable<tbItem> GetQueryable()
        {
            return _context.tbItems;
        }
        protected override tbItem GetEntity(Context entityContext, int id)
        {
            return entityContext.tbItems.FirstOrDefault(a => a.ID == id);
        }

    }
}