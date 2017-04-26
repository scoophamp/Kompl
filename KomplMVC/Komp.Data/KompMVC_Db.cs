using Komp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komp.Data
{
    class KompMVC_Db : DbContext
    {
        public DbSet<AlbumEM> AlbumEMS { get; set; }
        public DbSet<CommentEM> CommentEMS { get; set; }
        public DbSet<AlbumPhotoEM> AlbumPhotoEMS { get; set; }
        public DbSet<PhotoEM> PhotoEMS { get; set; }
    }
}
