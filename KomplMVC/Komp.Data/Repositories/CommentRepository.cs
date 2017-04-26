using Komp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komp.Data.Repositories
{
   public class CommentRepository
    {
        public void AddNewPhotoComment(Guid photoid, CommentEM newphotoComment)
        {
            using (var context = new KompMVC_Db())
            {
                var photoentity = context.PhotoEMS.FirstOrDefault(p => p.PhotoId == photoid);
                photoentity.Comment.Add(newphotoComment);
                context.PhotoEMS.AddOrUpdate(photoentity);
                context.SaveChanges();
            }
        }
        public void AddNewAlbumComment(Guid albumid, CommentEM newalbumCommet)
        {
            using (var context = new KompMVC_Db())
            {
                var albumentity = context.AlbumEMS.FirstOrDefault(a => a.AlbumId == albumid);
                albumentity.Comment.Add(newalbumCommet);
                context.AlbumEMS.AddOrUpdate(albumentity);
                context.SaveChanges();
            }
        }
    }
}
