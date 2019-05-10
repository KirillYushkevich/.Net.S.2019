using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Gallery.Models;

namespace Gallery.DAL
{
    public class GalleryContext : DbContext
    {
        public GalleryContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer<GalleryContext>(new DropCreateDatabaseIfModelChanges<GalleryContext>());
        }

        public DbSet<Photo> Photos { get; set; }
    }
}