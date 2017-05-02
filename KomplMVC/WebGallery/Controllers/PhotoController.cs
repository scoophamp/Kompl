using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheData.Repositories;
using WebGallery.Mapping;
using WebGallery.Models;

namespace WebGallery.Controllers
{
    
        public class PhotoController : Controller
        {
            private PhotoRepository PhotoRepository { get; set; }
            private CommentRepository CommentRepository { get; set; }

            public PhotoController()
            {
                PhotoRepository = new PhotoRepository();
                CommentRepository = new CommentRepository();
            }
            // GET: Photo
            public ActionResult Index(Guid id)
            {
                ViewBag.AlbumRefId = id;

                return View();
            }

            // GET: Photo/Details/5
            public ActionResult List(Guid id) // Album Id
            {
                var photos = PhotoRepository.Get(id);
                return PartialView("List", photos.ToModel());
            }



            public ActionResult Create(Guid id) // Album id
            {
                ViewBag.AlbumRefId = id;
                return PartialView();
            }
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create(PhotoViewModel model, HttpPostedFileBase file, Guid id)
            {
            model.DateAdded = DateTime.Now;
            if (ModelState.IsValid)
                {
                    if (file != null || file.ContentLength != 0)
                    {
                        
                        model.Id = Guid.NewGuid();
                        model.Url = @"/img/" + file.FileName;
                        model.AlbumRefId = id;
                        PhotoRepository.Add(model.ToEntity());

                        file.SaveAs(Path.Combine(Server.MapPath("~/img"), file.FileName));
                    }
                }

                return List(id);
            }
            public ActionResult Comment(Guid id)
            {
                var comments = CommentRepository.Get(id).ToModel();

                return PartialView("Comment", comments);
            }
            public ActionResult DeleteComment(Guid id)
            {
                CommentRepository.Delete(id);

                return null;
            }
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult CreateComment(string comment, Guid PictureRefId)
            {
                var model = new CommentViewModel();
                model.UserEmail = User.Identity.Name;
                model.PhotoRefId = PictureRefId;
                model.Id = Guid.NewGuid();
                model.Text = comment;
                CommentRepository.AddOrUppdate(model.ToEntity());

                return Comment(PictureRefId);
            }
            public ActionResult Delete(Guid id)
            {
                PhotoRepository.Delete(id);

                return null;
            }

        }
    }