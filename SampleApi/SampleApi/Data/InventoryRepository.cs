using SampleApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleApi.Data
{
    public class InventoryRepository : DataRepositoryBase<tbInventory>
    {
        public Context _context;
        public InventoryRepository(Context context)
        {
            _context = context;
        }

        public InventoryRepository()
        {

        }
        protected override tbInventory AddEntity(Context entityContext, tbInventory entity)
        {
            return entityContext.tbInventorys.Add(entity);
        }
        protected override tbInventory UpdateEntity(Context entityContext, tbInventory entity)
        {
            return entityContext.tbInventorys.FirstOrDefault(a => a.ID == entity.ID);
        }
        protected override IQueryable<tbInventory> GetEntities(Context entityContext)
        {
            return entityContext.tbInventorys;
        }
        protected override IQueryable<tbInventory> GetQueryable()
        {
            return _context.tbInventorys;
        }
        protected override tbInventory GetEntity(Context entityContext, int id)
        {
            return entityContext.tbInventorys.FirstOrDefault(a => a.ID == id);
        }

    }
}