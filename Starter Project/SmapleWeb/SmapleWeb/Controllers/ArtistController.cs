using DAOWEB.ApiRepo;
using SampleWeb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SmapleWeb.Controllers
{
    public class ArtistController : Controller
    {
        // GET: Artist
        public ActionResult Index()
        {
            ViewBag.sampleData = "AA";
            return View();
        }

        public async Task<ActionResult> _artistListPartial()
        {
            string url = string.Format("api/Artist/GetArtist");
            IEnumerable<Artist> result = await APIRequest<IEnumerable<Artist>>.Get(url);
            return PartialView("_artistListPartial", result);
        }

        //_ArtistForm
        public async Task<ActionResult> _ArtistForm(string FormType, int ID)
        {
            Artist Artist = new Artist();
            if (FormType == "Add")
            {
                return PartialView("_ArtistForm", Artist);
            }

            else
            {
                string url = string.Format("api/Artist/GetArtistByID?ID={0}", ID);
                Artist result = await APIRequest<Artist>.Get(url);
                return PartialView("_ArtistForm", result);
            }

        }

        //UpSertArtist
        public async Task<ActionResult> UpSertArtist(Artist Artist)
        {
           
            var url = "api/Artist/UpsertArtist";
            Artist result = await APIRequest<Artist>.Post(url, Artist);
            if (result != null)
            {
                return Json("Success", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Fail", JsonRequestBehavior.AllowGet);
            }
        }
    }
}