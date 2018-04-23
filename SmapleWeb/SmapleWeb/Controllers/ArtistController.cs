using DAOWEB.ApiRepo;
using SampleWeb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SampleWeb.Controllers
{
    public class ArtistController : Controller
    {
        // GET: Artist
        public ActionResult Index()
        {
            ViewBag.sampleData = "AA";
            return View();
        }

        public ActionResult Index2()
        {
            ViewBag.sampleData = "AA";
            Artist at = new Artist();
            at.Name = "Mgmg";
            // return View(at);
            return Json(at, JsonRequestBehavior.AllowGet);
        }


        public async Task<ActionResult> _artistListPartial()
        {
            string url = string.Format("api/Artist/GetArtist");
            IEnumerable<Artist> result = await APIRequest<IEnumerable<Artist>>.Get(url);
            return PartialView("_artistListPartial", result);
        }

        public async Task<ActionResult> getArtistListData()
        {
            string url = string.Format("api/Artist/GetArtist");
            IEnumerable<Artist> result = await APIRequest<IEnumerable<Artist>>.Get(url);
            return Json(result, JsonRequestBehavior.AllowGet);
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