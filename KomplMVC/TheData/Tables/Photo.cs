using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheData.Tables
{
    public class Photo
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public DateTime DateAdded { get; set; }
        public ICollection<Comment> Comments { get; set; }

        // ForeignKeys

        public Guid? AlbumRefID { get; set; }
        [ForeignKey(name: "AlbumRefID")]
        public virtual Album Album { get; set; }

    }
}
