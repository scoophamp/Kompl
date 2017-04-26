using Komp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komp.Data.Repositories
{
    public class PhotoRepository
    {
        public List<PhotoEM> GetAllPhoto()
        {
            using (var context = new KompMVC_Db())
            {
                var photos = context.PhotoEMS.Include("Comment").ToList();
                //context.PhotoEntityModels.AddOrUpdate(photos);
                return photos;
            }

        }
        public void AddPhoto(PhotoEM newphoto)
        {
            using (var context = new KompMVC_Db())
            {
                PhotoEM photo = new PhotoEM();
                photo.PhotoId = newphoto.PhotoId;
                photo.PhotoName = newphoto.PhotoName;
                photo.Comment = newphoto.Comment;
                context.PhotoEMS.Add(photo);
                context.PhotoEMS.AddOrUpdate(photo);
                context.SaveChanges();
            }
        }
        public void DeletePhoto(PhotoEM photo)
        {
            using (var context = new KompMVC_Db())
            {
                var photoToDelete = context.PhotoEMS.Include("Comment").FirstOrDefault(p => p.PhotoId == photo.PhotoId);
                context.PhotoEMS.Remove(photoToDelete);
                context.PhotoEMS.AddOrUpdate(photoToDelete);
                context.SaveChanges();
            }
        }

        public PhotoEM GetPhoto(Guid id)
        {
            using (var context = new KompMVC_Db())
            {
                return context.PhotoEMS.Include("Comment").FirstOrDefault(p => p.PhotoId == id);
            }
        }
        public PhotoEM AddCommentToPhoto(Guid id, string photoComment)
        {
            using (var context = new KompMVC_Db())
            {
                var phototocomment = context.PhotoEMS.Include("Comment").FirstOrDefault(x => x.PhotoId == id);
                phototocomment.Comment.Add(new CommentEM { Id = Guid.NewGuid(), CommentPhoto = photoComment });
                context.PhotoEMS.AddOrUpdate(phototocomment);
                context.SaveChanges();
                return phototocomment;
            }
        }
    }
}
