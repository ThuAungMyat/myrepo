using SampleApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleApi.Data
{
    public class StockRepository : DataRepositoryBase<tbStock>
    {
        public Context _context;
        public StockRepository(Context context)
        {
            _context = context;
        }

        public StockRepository()
        {

        }
        protected override tbStock AddEntity(Context entityContext, tbStock entity)
        {
            return entityContext.tbStocks.Add(entity);
        }
        protected override tbStock UpdateEntity(Context entityContext, tbStock entity)
        {
            return entityContext.tbStocks.FirstOrDefault(a => a.ID == entity.ID);
        }
        protected override IQueryable<tbStock> GetEntities(Context entityContext)
        {
            return entityContext.tbStocks;
        }
        protected override IQueryable<tbStock> GetQueryable()
        {
            return _context.tbStocks;
        }
        protected override tbStock GetEntity(Context entityContext, int id)
        {
            return entityContext.tbStocks.FirstOrDefault(a => a.ID == id);
        }

    }
}