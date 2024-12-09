using Art_Gallery_Management.Data;
using Art_Gallery_Management.Models.Artists;
using Microsoft.EntityFrameworkCore;

namespace Art_Gallery_Management.Repositories.ArtistRepository
{
    public class ArtistRepository : IArtistRepository

    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Artist> _artists;
        public ArtistRepository(ApplicationDbContext context) {
            _context = context;
            _artists = context.Set<Artist>();

        }

        public  async Task<Artist> CreateArtist(Artist artist)
        {
            await _artists.AddAsync(artist);
            await _context.SaveChangesAsync();
            return artist;

        }

        public async Task<Artist> DeleteArtist(Artist artist)
        {
           
            _artists.Remove(artist);
            await _context.SaveChangesAsync();
            return artist;

        }

        public  async Task<Artist> GetById(int id)
        {
            return await _artists.FindAsync(id);
        }

        public async Task<Artist> UpdateArtist(Artist artist, int id)
        {
            
            _artists.Update(artist);
            await _context.SaveChangesAsync();
            return artist;

        }
    }
}
