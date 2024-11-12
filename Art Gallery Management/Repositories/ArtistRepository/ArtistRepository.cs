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

        public  Artist CreateArtist(Artist artist)
        {
            _artists.Add(artist);
            _context.SaveChanges();
            return artist;

        }

        public void DeleteArtist(int id)
        {
            Artist artist = _artists.FirstOrDefault(a => a.Id == id);
            _artists.Remove(artist);
            _context.SaveChanges();

        }

        public  Artist GetById(int id)
        {
            return _artists.Find(id);
        }

        public Artist UpdateArtist(Artist artist, int id)
        {
            
            _artists.Update(artist);
            _context.SaveChanges();
            return artist;

        }
    }
}
