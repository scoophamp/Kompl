using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheData.Repositories;
using WebGallery.Mapping;
using WebGallery.Models;

namespace WebGallery.Controllers
{
    [Authorize]
    public class AlbumController : Controller
    {
        private AlbumRepository AlbumRepository { get; set; }
       
        private CommentRepository CommentRepository { get; set; }

        public AlbumController()
        {
            this.AlbumRepository = new AlbumRepository();
  
            this.CommentRepository = new CommentRepository();
        }
        // GET: Album
        public ActionResult Index()
        {
            //var pr = new PhotoRepository();
            //pr.Clear();
            //AlbumRepository.Clear();
            return View();
        }

        public ActionResult List()
        {
            var email = User.Identity.Name;

            var model = AlbumRepository.Get(email).ToModel();
            return PartialView("List", model);
        }



        // GET: Album/Create

        // POST: Album/Create
        public ActionResult Create()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Create(AlbumViewModel collection)
        {
            if (ModelState.IsValid)
            {
                collection.UserEmail = User.Identity.Name;
                collection.Id = Guid.NewGuid();

                AlbumRepository.AddOrUpdate(collection.ToEntity());
            }

            return View("Index");
        }

        public ActionResult Comment(Guid id)
        {
            var comments = CommentRepository.Get(id).ToModel();

            return PartialView("Comment", comments);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateComment(string comment, Guid AlbumRefId)
        {
            var model = new CommentViewModel();
            model.UserEmail = User.Identity.Name;
            model.AlbumRefId = AlbumRefId;
            model.Id = Guid.NewGuid();
            model.Text = comment;
            CommentRepository.AddOrUppdate(model.ToEntity());

            return Comment(AlbumRefId);
        }

        public ActionResult DeleteComment(Guid id)
        {
            CommentRepository.Delete(id);

            return null;
        }
        // GET: Album/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = AlbumRepository.Get(id).ToModel();

            return View(model);
        }

        // POST: Album/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, AlbumViewModel collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    AlbumRepository.AddOrUpdate(collection.ToEntity());

                    return RedirectToAction("Index");
                }

                return View(collection);
            }
            catch
            {
                return View();
            }
        }

        // GET: Album/Delete/5
        public ActionResult Delete(Guid id)
        {
            AlbumRepository.Delete(id);

            return View("Index");
        }

        // POST: Album/Delete/5


    }
}