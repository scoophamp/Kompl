using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Komp.Data.Entities;
using Komp.Data.Repositories;
using KomplMVC.Models;

namespace KomplMVC.Mapping
{
    public class PhotoAlbumModelMapper
    {
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
                //AlbumID = photo.AlbumID
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
                //AlbumID = photo.AlbumID
            };
        }
        public static ICollection<Album> MapAlbumModel(ICollection<AlbumEM> album)
        {
            var result = new List<Album>();
            album.ToList().ForEach(x => result.Add(MapAlbumModel(x)));
            return result;
        }
        public static Album MapAlbumModel(AlbumEM album)
        {
            return new Album
            {
                AlbumId = album.AlbumId,
                AlbumName = album.AlbumName,
                AlbumComment = album.Comment.Select(x => CommentsModelMapper.ModelToEntity(x)).ToList()
            };
        }
        public static ICollection<AlbumEM> MapAlbumEntityModel(ICollection<Album> comments)
        {
            var result = new List<AlbumEM>();
            comments.ToList().ForEach(x => result.Add(MapAlbumEntityModel(x)));
            return result;
        }
        public static AlbumEM MapAlbumEntityModel(Album album)
        {
            return new AlbumEM
            {
                AlbumId = album.AlbumId,
                AlbumName = album.AlbumName,
                Comment = album.AlbumComment.Select(x => CommentsModelMapper.EntityToModel(x)).ToList(),
                Photo = album.AlbumPhoto.Select(x => PhotoModelMapper.EntityToModel(x)).ToList()
            };
        }


    }
}
