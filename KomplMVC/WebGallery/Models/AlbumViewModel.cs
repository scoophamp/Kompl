using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebGallery.Models
{
    public class AlbumViewModel
    {
        public List<PhotoViewModel> Photos { get; set; }
        public List<CommentViewModel> Comments { get; set; }
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Please enter name for album")]
        public string Name { get; set; }
        public string UserEmail { get; set; }
    }
}