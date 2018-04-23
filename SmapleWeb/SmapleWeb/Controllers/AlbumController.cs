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
    public class AlbumController : Controller
    {
        // GET: Album
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> _albumListPartial()
        {
            string url = string.Format("api/Album/GetAlbum");
            IEnumerable<Album> result = await APIRequest<IEnumerable<Album>>.Get(url);
            return PartialView("_albumListPartial", result);
        }

        //_AlbumForm
        public async Task<ActionResult> _AlbumForm(string FormType, int ID)
        {
            Album Album = new Album();
            if (FormType == "Add")
            {
                return PartialView("_AlbumForm", Album);
            }

            else
            {
                string url = string.Format("api/Album/GetAlbumByID?ID={0}", ID);
                Album result = await APIRequest<Album>.Get(url);
                return PartialView("_AlbumForm", result);
            }

        }

        //UpSertAlbum
        public async Task<ActionResult> UpSertAlbum(Album Album)
        {

            var url = "api/Album/UpsertAlbum";
            Album result = await APIRequest<Album>.Post(url, Album);
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