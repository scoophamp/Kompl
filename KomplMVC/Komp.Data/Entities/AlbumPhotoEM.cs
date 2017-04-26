using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komp.Data.Entities
{
   public class AlbumPhotoEM
    {
        public AlbumPhotoEM()
        {

            Photon = new HashSet<PhotoEM>();
            Albumer = new HashSet<AlbumEM>();
        }
        [Key]
        public Guid Id { get; set; }
        public virtual ICollection<PhotoEM> Photon { get; set; }
        public virtual ICollection<AlbumEM> Albumer { get; set; }
    }
}
