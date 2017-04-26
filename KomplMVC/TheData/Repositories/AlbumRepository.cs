using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TheData.Tables;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace TheData.Repositories
{
    public class AlbumRepository
    {
        public List<Album> Get(string email)
        {
            using (var ctx = new GalleryContext())
            {
                return ctx.Albums.Where(x => x.UserEmail == email).Include(x => x.Photos).Include(x => x.Comments).ToList();
            }
        }
        public Album Get(Guid id)
        {
            using (var ctx = new GalleryContext())
            {
                return ctx.Albums.Include(x => x.Photos).Include(x => x.Comments).FirstOrDefault(x => x.Id == id);
            }
        }

        public void Clear()
        {
            using (var ctx = new GalleryContext())
            {
                var albums = ctx.Albums;
                ctx.Albums.RemoveRange(albums);
            }
        }

        public void AddOrUpdate(Album album)
        {
            using (var ctx = new GalleryContext())
            {

                var entityToAddORUpdate = ctx.Albums.FirstOrDefault(x => x.Id == album.Id) ?? new Album()
                {
                    Id = album.Id,
                    UserEmail = album.UserEmail
                };

                entityToAddORUpdate.Name = album.Name;

                ctx.Albums.AddOrUpdate(entityToAddORUpdate);
                ctx.SaveChanges();
            }
        }
        public void Delete(Guid Id)
        {
            using (var ctx = new GalleryContext())
            {
                var entityToDelete = ctx.Albums.Find(Id);


                var commetnsToDelete = ctx.Comments.Where(x => x.AlbumRefID == Id).ToList();

                var picturesToDelete = ctx.Photos.Where(x => x.AlbumRefID == Id);
                foreach (var picture in picturesToDelete)
                {
                    var deleteMe = ctx.Comments.Where(x => x.PhotoRefID == picture.Id);
                    commetnsToDelete.AddRange(deleteMe);
                }

                ctx.Comments.RemoveRange(commetnsToDelete);
                ctx.Photos.RemoveRange(picturesToDelete);

                ctx.Albums.Remove(entityToDelete);
                ctx.SaveChanges();
            }
        }
    }
}
