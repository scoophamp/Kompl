using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheData.Tables;
using WebGallery.Models;
using WebGrease.Css.Extensions;

namespace WebGallery.Mapping
{
    public static class PhotoMapping
    {
        public static PhotoViewModel ToModel(this Photo entity)
        {
            var model = new PhotoViewModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Url = entity.Url,
                DateAdded = entity.DateAdded,
                AlbumRefId = entity.AlbumRefID ?? Guid.Empty,
                Comments = entity.Comments.ToModel()
            };

            return model;
        }
        public static List<PhotoViewModel> ToModel(this ICollection<Photo> entitys)
        {
            var model = new List<PhotoViewModel>();

            entitys.ForEach(x => model.Add(x.ToModel()));

            return model;
        }

        public static Photo ToEntity(this PhotoViewModel model)
        {
            var entity = new Photo()
            {
                Id = model.Id,
                Name = model.Name,
                Url = model.Url,
                DateAdded = model.DateAdded,
                AlbumRefID = model.AlbumRefId,
                Comments = model.Comments.ToEntity(),
            };
            return entity;
        }
        public static List<Photo> ToEntity(this ICollection<PhotoViewModel> model)
        {
            var entity = new List<Photo>();

            model.ForEach(x => entity.Add(x.ToEntity()));

            return entity;
        }

    }
}