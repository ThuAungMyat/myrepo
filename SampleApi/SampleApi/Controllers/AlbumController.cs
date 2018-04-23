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
    public class AlbumController : ApiController
    {
        [HttpGet]
        [Route("api/Album/GetAlbum")]
        public HttpResponseMessage GetAlbum(HttpRequestMessage request)
        {
            AlbumManager AlbumMgr = new AlbumManager();
            IEnumerable<Album> result = AlbumMgr.getAlbum();
            return request.CreateResponse<IEnumerable<Album>>(HttpStatusCode.OK, result);
        }
        [HttpGet]
        [Route("api/Album/GetAlbum2")]
        public HttpResponseMessage GetAlbum2(HttpRequestMessage request)
        {
            using (var ctx = new Context())
            {
                List<Album> result = ctx.Albums.Where(a => a.IsDeleted != true).ToList();
                return request.CreateResponse<IEnumerable<Album>>(HttpStatusCode.OK, result);
            }


        }

        [HttpGet]
        [Route("api/Album/GetAlbumByID")]
        public HttpResponseMessage GetAlbumByID(HttpRequestMessage request, int ID)
        {
            AlbumManager AlbumMgr = new AlbumManager();
            Album result = AlbumMgr.getAlbumByID(ID);
            return request.CreateResponse<Album>(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("api/Album/UpsertAlbum")]
        public HttpResponseMessage UpsertAlbum(HttpRequestMessage request, Album Album)
        {
            AlbumManager AlbumMgr = new AlbumManager();
            Album result = AlbumMgr.UpsertAlbum(Album);
            return request.CreateResponse<Album>(HttpStatusCode.OK, result);
        }

    }
}
