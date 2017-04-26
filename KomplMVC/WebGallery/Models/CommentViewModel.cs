using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebGallery.Models
{
    public class CommentViewModel
    {
        public Guid Id { get; set; }
        public string Text { get; set; }

        public string UserEmail { get; set; }

        public AlbumViewModel Album { get; set; }
        public PhotoViewModel Photo { get; set; }
        public Guid AlbumRefId { get; set; }
        public Guid PhotoRefId { get; set; }

    }
}