using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheData.Tables;

namespace TheData.Repositories
{
    public class CommentRepository
    {
        public List<Comment> Get()
        {
            using (var ctx = new GalleryContext())
            {
                return ctx.Comments.ToList();
            }
        }

        public ICollection<Comment> Get(Guid id)
        {
            using (var ctx = new GalleryContext())
            {
                var result = ctx.Comments.Where(x => x.AlbumRefID == id).ToList();
                result = result.Count > 0 ? result : ctx.Comments.Where(x => x.PhotoRefID == id).ToList();
                return result;
            }
        }

        public void AddOrUppdate(Comment comment)
        {
            using (var ctx = new GalleryContext())
            {

                var entityToAddORUpdate = ctx.Comments.FirstOrDefault(x => x.Id == comment.Id) ?? new Comment()
                {
                    Id = comment.Id,
                    UserEmail = comment.UserEmail
                };
                if (!string.IsNullOrEmpty(comment.Text))
                {
                    entityToAddORUpdate.AlbumRefID = (comment.AlbumRefID != Guid.Empty) ? comment.AlbumRefID : null;

                    entityToAddORUpdate.PhotoRefID = (comment.PhotoRefID != Guid.Empty) ? comment.PhotoRefID : null;

                    entityToAddORUpdate.Text = comment.Text;

                    ctx.Comments.AddOrUpdate(entityToAddORUpdate);
                    ctx.SaveChanges();
                }
            }
        }

        public void Delete(Guid id)
        {
            using (var ctx = new GalleryContext())
            {
                var commetntoDelete = ctx.Comments.Find(id);
                ctx.Comments.Remove(commetntoDelete);
                ctx.SaveChanges();
            }
        }
    }
}
