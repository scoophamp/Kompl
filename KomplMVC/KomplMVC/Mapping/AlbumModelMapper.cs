using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Komp.Data.Entities;
using Komp.Data.Repositories;
using KomplMVC.Models;


namespace KomplMVC.Mapping
{
    public class AlbumModelMapper
    {
        public static AlbumEM EntityToModel(Album albumModel)
        {
            AlbumEM entity = new AlbumEM();
            entity.AlbumId = albumModel.AlbumId;
            entity.AlbumName = albumModel.AlbumName;
            //entity.Photo = MapPhotoEntityModel(albumModel.Photos);
            entity.Comment = MapCommentsEntityModel(albumModel.AlbumComment);
            return entity;
        }
        public static Album ModelToEntity(AlbumEM entityModel)
        {
            var model = new Album();
            model.AlbumId = entityModel.AlbumId;
            model.AlbumName = entityModel.AlbumName;
            //model.Photos = MapPhotoModel(entityModel.Photo);
            model.AlbumComment = MapCommentsModel(entityModel.Comment);
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
                CommentPhoto = comments.CommentOnPicture,
                CommentAlbum = comments.CommentOnAlbum
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
        public static ICollection<Photo> MapPhotoModel(ICollection<PhotoEM> photo)
        {
            var result = new List<Photo>();
            photo.ToList().ForEach(x => result.Add(MapPhotoModel(x)));
            return result;
        }
        public static Photo MapPhotoModel(PhotoEM photo)
        {
            return new Photo
            {
                PhotoID = photo.PhotoId,
                PhotoName = photo.PhotoName,
                PhotoComment = PhotoModelMapper.MapCommentsModel(photo.Comment),
                //AlbumID=photo.AlbumID
            };
        }
        public static ICollection<PhotoEM> MapPhotoEntityModel(ICollection<Photo> comments)
        {
            var result = new List<PhotoEM>();
            comments.ToList().ForEach(x => result.Add(MapPhotoEntityModel(x)));
            return result;
        }
        public static PhotoEM MapPhotoEntityModel(Photo photo)
        {
            return new PhotoEM
            {
                PhotoId = photo.PhotoID,
                PhotoName = photo.PhotoName,
                Comment = PhotoModelMapper.MapCommentsEntityModel(photo.PhotoComment),
                //AlbumID=photo.AlbumID
            };
        }
    }
}