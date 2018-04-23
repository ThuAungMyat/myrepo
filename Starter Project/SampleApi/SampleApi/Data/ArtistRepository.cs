
using SampleApi.Data;
using SampleApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KoeKoeTech.DAO.DAOApi.Data
{
    public class ArtistRepository : DataRepositoryBase<Artist>
    {
        public Context _context;
        public ArtistRepository(Context context)
        {
            _context = context;
        }

        public ArtistRepository()
        {

        }
        protected override Artist AddEntity(Context entityContext, Artist entity)
        {
            return entityContext.Artists.Add(entity);
        }
        protected override Artist UpdateEntity(Context entityContext, Artist entity)
        {
            return entityContext.Artists.FirstOrDefault(a => a.ID == entity.ID);
        }
        protected override IQueryable<Artist> GetEntities(Context entityContext)
        {
            return entityContext.Artists;
        }
        protected override IQueryable<Artist> GetQueryable()
        {
            return _context.Artists;
        }
        protected override Artist GetEntity(Context entityContext, int id)
        {
            return entityContext.Artists.FirstOrDefault(a => a.ID == id);
        }

    }
}