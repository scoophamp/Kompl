using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KomplMVC.Models
{
    public class Album
    {
        public Guid AlbumId { get; set; }
        public string AlbumName { get; set; }

        public ICollection<Comments> AlbumComment { get; set; }

        public ICollection<Photo> AlbumPhoto { get; set; }
    }
}