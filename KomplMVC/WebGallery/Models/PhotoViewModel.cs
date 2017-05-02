using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebGallery.Models
{
    public class PhotoViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Please enter name for photo")]
        public string Name { get; set; }
        public string Url { get; set; }
        public DateTime DateAdded { get; set; }
        public List<CommentViewModel> Comments { get; set; }

        public AlbumViewModel Album { get; set; }
        public Guid AlbumRefId { get; set; }
    }
}