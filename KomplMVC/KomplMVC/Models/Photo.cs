using System;
using System.Collections.Generic;

namespace KomplMVC.Models
{
    public class Photo
    {
        public Guid PhotoID { get; set; }
        public string PhotoName { get; set; }
        public ICollection<Comments> PhotoComment { get; set; }
    }
}