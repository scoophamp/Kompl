using Komp.Data.Repositories;
using KomplMVC.Mapping;
using KomplMVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace KomplMVC.Controllers
{
    public class GalleryController : Controller
    {
        PhotoRepository photoRepo = new PhotoRepository();

        // GET: Gallery
        public ActionResult Index()
        {
            return View();
        }
        
    }
}