using KoeKoeTech.DAO.DAOApi.Data;
using SampleApi.Data;
using SampleApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleApi.Manager
{
    public class AlbumManager
    {
        public IEnumerable<Album> getAlbum()
        {
            Context ctx = new Context();
            AlbumRepository albumRepo = new AlbumRepository(ctx);

            IEnumerable<Album> result = albumRepo.GetDataSet().Where(a => a.IsDeleted != true).ToList();
            ctx.Dispose();
            return result;
        }

        public Album getAlbumByID(int ID)
        {
            Context ctx = new Context();
            AlbumRepository albumRepo = new AlbumRepository(ctx);
            Album result = albumRepo.GetDataSet().Where(a => a.IsDeleted != true && a.ID == ID).FirstOrDefault();
            ctx.Dispose();
            return result;
        }

        public Album UpsertAlbum(Album Album)
        {
            Context ctx = new Context();
            AlbumRepository albumRepo = new AlbumRepository(ctx);
            Album UpdatedEntity = null;
            if (Album.ID > 0)
            {
                UpdatedEntity = albumRepo.update(Album);
            }
            else
            {
                UpdatedEntity = albumRepo.Add(Album);
            }
            return UpdatedEntity;
        }
    }
}