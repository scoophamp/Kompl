using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komp.Data.Entities
{
   public class PhotoEM
    {
        public PhotoEM()
        {
            Comment = new HashSet<CommentEM>();
        }
        [Key]
        public Guid PhotoId { get; set; }
        public string PhotoName { get; set; }
        public virtual ICollection<CommentEM> Comment { get; set; }
    }
}
