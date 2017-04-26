using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Komp.Data.Entities;
using Komp.Data.Repositories;
using KomplMVC.Models;

namespace KomplMVC.Mapping
{
    public class CommentsModelMapper
    {
        public static CommentEM EntityToModel(Comments comments)
        {
            CommentEM entity = new CommentEM();
            entity.Id = comments.Id;
            entity.CommentPhoto = comments.CommentOnPicture;
            entity.CommentAlbum = comments.CommentOnAlbum;
            return entity;
        }
        public static Comments ModelToEntity(CommentEM comments)
        {
            Comments model = new Comments();
            model.Id = comments.Id;
            model.CommentOnPicture = comments.CommentPhoto;
            model.CommentOnAlbum = comments.CommentAlbum;
            return model;
        }
    }
}