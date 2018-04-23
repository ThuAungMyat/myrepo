using SampleApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleApi.Data
{
    public class AlbumRepository : DataRepositoryBase<Album>
    {
        public Context _context;
        public AlbumRepository(Context context)
        {
            _context = context;
        }

        public AlbumRepository()
        {

        }
        protected override Album AddEntity(Context entityContext, Album entity)
        {
            return entityContext.Albums.Add(entity);
        }
        protected override Album UpdateEntity(Context entityContext, Album entity)
        {
            return entityContext.Albums.FirstOrDefault(a => a.ID == entity.ID);
        }
        protected override IQueryable<Album> GetEntities(Context entityContext)
        {
            return entityContext.Albums;
        }
        protected override IQueryable<Album> GetQueryable()
        {
            return _context.Albums;
        }
        protected override Album GetEntity(Context entityContext, int id)
        {
            return entityContext.Albums.FirstOrDefault(a => a.ID == id);
        }

    }
}