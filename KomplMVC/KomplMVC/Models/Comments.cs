using System;

namespace KomplMVC.Models
{
    public class Comments
    {
        public Guid Id { get; set; }
        public string CommentOnPicture { get; set; }
        public string CommentOnAlbum { get; set; }
    }
}