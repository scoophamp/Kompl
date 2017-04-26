using Komp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komp.Data.Repositories
{
   public class AlbumRepository
    {
        public List<AlbumEM> GetAllAlbums()
        {

            using (var context = new KompMVC_Db())
            {

                var albums = context.AlbumEMS.Include("Comment").Include("Photo").ToList();
                return albums;
            }

        }
        public void AddNewAlbum(AlbumEM newalbum)
        {
            using (var context = new KompMVC_Db())
            {
                AlbumEM album = new AlbumEM();
                album.AlbumId = newalbum.AlbumId;
                album.AlbumName = newalbum.AlbumName;
                album.Comment = newalbum.Comment;
                //album.Photo = newalbum.Photo;
                context.AlbumEMS.Add(album);
                context.AlbumEMS.AddOrUpdate(album);
                context.SaveChanges();
            }
        }
        public AlbumEM ShowAlbum(Guid id)
        {
            using (var context = new KompMVC_Db())
            {
                return context.AlbumEMS.Include("Comment").FirstOrDefault(x => x.AlbumId == id);

            }

        }
        public AlbumEM AddCommentToAlbum(Guid id, string albumComment)
        {
            using (var context = new KompMVC_Db())
            {
                var albumtocomment = context.AlbumEMS.Include("Comment").FirstOrDefault(x => x.AlbumId == id);
                albumtocomment.Comment.Add(new CommentEM { Id = Guid.NewGuid(), CommentAlbum = albumComment });
                context.AlbumEMS.AddOrUpdate(albumtocomment);
                context.SaveChanges();
                return albumtocomment;
            }
        }
        public void AddPhotoToAlbum(IEnumerable<Guid> photos, Guid albumID)
        {
            using (var context = new KompMVC_Db())
            {
                var albumToAddIn = context.AlbumEMS.FirstOrDefault(x => x.AlbumId == albumID);
                foreach (var item in photos)
                {
                    albumToAddIn.Photo.Add(context.PhotoEMS.Include("Comment").FirstOrDefault(x => x.PhotoId == item));
                }
                context.AlbumEMS.AddOrUpdate(albumToAddIn);
                context.SaveChanges();
            }
        }
    }
}
