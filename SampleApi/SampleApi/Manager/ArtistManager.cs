using KoeKoeTech.DAO.DAOApi.Data;
using SampleApi.Data;
using SampleApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleApi.Manager
{
    public class ArtistManager
    {
        public IEnumerable<Artist> getArtist()
        {
            Context ctx = new Context();
            ArtistRepository artistRepo = new ArtistRepository(ctx);

            IEnumerable<Artist> result = artistRepo.GetDataSet().Where(a=>a.IsDeleted != true).ToList();
            ctx.Dispose();
            return result;
        }

        public Artist getArtistByID(int ID)
        {
            Context ctx = new Context();
            ArtistRepository artistRepo = new ArtistRepository(ctx);
            Artist result = artistRepo.GetDataSet().Where(a => a.IsDeleted != true && a.ID == ID).FirstOrDefault();
            ctx.Dispose();
            return result;
        }

        public Artist UpsertArtist(Artist Artist)
        {
            Context ctx = new Context();
            ArtistRepository artistRepo = new ArtistRepository(ctx);
            Artist UpdatedEntity = null;
            if (Artist.ID > 0)
            {
                UpdatedEntity = artistRepo.update(Artist);
            }
            else
            {
                UpdatedEntity = artistRepo.Add(Artist);
            }
            return UpdatedEntity;
        }
    }
}