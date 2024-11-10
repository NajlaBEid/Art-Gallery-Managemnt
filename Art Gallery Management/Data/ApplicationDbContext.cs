using Art_Gallery_Management.Models.Artists;
using Art_Gallery_Management.Models.ArtWorks;
using Art_Gallery_Management.Models.Exhibitions;
using Art_Gallery_Management.Models.Managers;
using Microsoft.EntityFrameworkCore;

namespace Art_Gallery_Management.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) :base(options)
        {
            
        }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Exhibition> Exhibitions { get; set; }
        public DbSet<ArtWork> Artworks { get; set; }
        public DbSet<Artist> Artists { get; set; }

    }
}
