using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Komp.Data.Entities;
using Komp.Data.Repositories;
using KomplMVC.Models;

namespace KomplMVC.Mapping
{
    public class PhotoModelMapper
    {
        public static PhotoEM EntityToModel(Photo photoModel)
        {
            PhotoEM entity = new PhotoEM();
            entity.PhotoId = photoModel.PhotoID;
            entity.PhotoName = photoModel.PhotoName;
            entity.Comment = MapCommentsEntityModel(photoModel.PhotoComment);
            //entity.AlbumID = photoModel.AlbumID;
            return entity;
        }
        public static Photo ModelToEntity(PhotoEM photoentity)
        {
            Photo model = new Photo();
            model.PhotoID = photoentity.PhotoId;
            model.PhotoName = photoentity.PhotoName;
            model.PhotoComment = MapCommentsModel(photoentity.Comment);
            //model.AlbumID = photoentity.AlbumID;
            return model;
        }
        public static ICollection<CommentEM> MapCommentsEntityModel(ICollection<Comments> comments)
        {
            var result = new List<CommentEM>();
            comments.ToList().ForEach(x => result.Add(MapCommentsEntityModel(x)));
            return result;
        }
        public static CommentEM MapCommentsEntityModel(Comments comments)
        {
            return new CommentEM
            {
                Id = comments.Id,
                CommentPhoto = comments.CommentOnPicture
                //CommentAlbum = comments.CommentOnAlbum
            };
        }
        public static ICollection<Comments> MapCommentsModel(ICollection<CommentEM> comments)
        {
            var result = new List<Comments>();
            comments.ToList().ForEach(x => result.Add(MapCommentsModel(x)));
            return result;
        }
        public static Comments MapCommentsModel(CommentEM comments)
        {
            return new Comments
            {
                Id = comments.Id,
                CommentOnPicture = comments.CommentPhoto,
                CommentOnAlbum = comments.CommentAlbum
            };
        }
    }
}