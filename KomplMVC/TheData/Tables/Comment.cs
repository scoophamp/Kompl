using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheData.Tables
{
    public class Comment
    {
        public Guid Id { get; set; }
        [Required]
        public string Text { get; set; }


        //ForeignKeys
        public Guid? PhotoRefID { get; set; }
        [ForeignKey(name: "PhotoRefID")]
        public virtual Photo Photo { get; set; }

        public Guid? AlbumRefID { get; set; }
        [ForeignKey(name: "AlbumRefID")]
        public virtual Album Album { get; set; }

        public string UserEmail { get; set; }
    }
}
