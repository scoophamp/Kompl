using Komp.Data.Repositories;
using KomplMVC.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KomplMVC.Controllers
{
    public class AlbumController : Controller
    {
        AlbumRepository albumrepo = new AlbumRepository();
        PhotoRepository photorepo = new PhotoRepository();
        // GET: Album
        public ActionResult Index()
        {
            //return View(albumrepo.GetAllAlbums().Select(x => AlbumModelMapper.ModelToEntity(x)).ToList());
            return View();
        }
    }
}