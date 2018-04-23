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
    public class ArtistController : ApiController
    {
        [HttpGet]
        [Route("api/Artist/GetArtist")]
        public HttpResponseMessage GetArtist(HttpRequestMessage request)
        {
            ArtistManager ArtistMgr = new ArtistManager();
            IEnumerable<Artist> result = ArtistMgr.getArtist();
            return request.CreateResponse<IEnumerable<Artist>>(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("api/Artist/GetArtistByID")]
        public HttpResponseMessage GetArtistByID(HttpRequestMessage request,int ID)
        {
            ArtistManager ArtistMgr = new ArtistManager();
            Artist result = ArtistMgr.getArtistByID(ID);
            return request.CreateResponse<Artist>(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("api/Artist/UpsertArtist")]
        public HttpResponseMessage UpsertArtist(HttpRequestMessage request, Artist Artist)
        {
            ArtistManager ArtistMgr = new ArtistManager();
            Artist result = ArtistMgr.UpsertArtist(Artist);
            return request.CreateResponse<Artist>(HttpStatusCode.OK, result);
        }
        

    }
}
