using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komp.Data.Entities
{
   public class AlbumEM
    {
        public AlbumEM()
        {
            Comment = new HashSet<CommentEM>();
            Photo = new HashSet<PhotoEM>();
        }
        [Key]
        public Guid AlbumId { get; set; }
        public string AlbumName { get; set; }

        public virtual ICollection<CommentEM> Comment { get; set; }
        public virtual ICollection<PhotoEM> Photo { get; set; }
    }
}
