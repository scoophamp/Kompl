﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komp.Data.Entities
{
   public class CommentEM
    {
        [Key]
        public Guid Id { get; set; }
        public string CommentPhoto { get; set; }
        public string CommentAlbum { get; set; }
    }
}
