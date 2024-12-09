using Art_Gallery_Management.Data;
using Art_Gallery_Management.Models.Artists;
using Art_Gallery_Management.Models.ArtWorks;
using Microsoft.EntityFrameworkCore;

namespace Art_Gallery_Management.Repositories.ArtWorkRepository
{
    public class ArtWorkRepository : IArtWorkRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<ArtWork> _artWorks;

        public ArtWorkRepository(ApplicationDbContext context)
        {
            _context = context;
            _artWorks = context.Set<ArtWork>();

        }
        public async Task<ArtWork> CreateArtWork(ArtWork artWork)
        {
             await _artWorks.AddAsync(artWork);
             await _context.SaveChangesAsync();
            return artWork;
        }

        public async Task<ArtWork> GetArtWorkById(int id)
        {
            return await _artWorks.FindAsync(id);
        }

        public async Task<ArtWork> UpdateArtWork(ArtWork artWork, int id)
        {
           
            _artWorks.Update(artWork);
            await _context.SaveChangesAsync();
            return artWork;
        }
        public async Task<ArtWork> DeleteArtWork(ArtWork artWork)
        {
             _artWorks.Remove(artWork);
             await _context.SaveChangesAsync();
            return artWork;
            
        }
    }
}
