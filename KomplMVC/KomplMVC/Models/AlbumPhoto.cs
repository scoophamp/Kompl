using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KomplMVC.Models
{
    public class AlbumPhoto
    {
        public Guid ID { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public ICollection<Album> Albums { get; set; }
    }
}