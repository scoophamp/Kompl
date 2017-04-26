using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheData.Tables;
using WebGallery.Models;
using WebGrease.Css.Extensions;

namespace WebGallery.Mapping
{
    public static class CommentMapping
    {
        public static CommentViewModel ToModel(this Comment entity)
        {
            var model = new CommentViewModel()
            {
                Id = entity.Id,
                Text = entity.Text,
                UserEmail = entity.UserEmail,
                AlbumRefId = entity.AlbumRefID ?? Guid.Empty,
                PhotoRefId = entity.PhotoRefID ?? Guid.Empty,
            };



            return model;
        }
        public static List<CommentViewModel> ToModel(this ICollection<Comment> entitys)
        {
            var model = new List<CommentViewModel>();

            entitys.ForEach(x => model.Add(x.ToModel()));
            return model;
        }

        public static Comment ToEntity(this CommentViewModel model)
        {
            var entity = new Comment()
            {
                Id = model.Id,
                Text = model.Text,
                UserEmail = model.UserEmail,
                AlbumRefID = model.AlbumRefId,
                PhotoRefID = model.PhotoRefId,


            };
            return entity;
        }
        public static List<Comment> ToEntity(this ICollection<CommentViewModel> model)
        {
            var entity = new List<Comment>();

            model.ForEach(x => entity.Add(x.ToEntity()));

            return entity;
        }
    }
}