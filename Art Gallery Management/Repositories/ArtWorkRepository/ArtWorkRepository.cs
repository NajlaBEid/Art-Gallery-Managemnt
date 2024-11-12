using Art_Gallery_Management.Data;
using Art_Gallery_Management.Models.Artists;
using Art_Gallery_Management.Models.ArtWorks;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

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
        public ArtWork CreateArtWork(ArtWork artWork)
        {
            _artWorks.Add(artWork);
            _context.SaveChanges();
            return artWork;
        }

        public ArtWork GetArtWorkById(int id)
        {
            return _artWorks.Find(id);
        }

        public ArtWork UpdateArtWork(ArtWork artWork, int id)
        {
            _artWorks.Update(artWork);
            _context.SaveChanges();
            return artWork;
        }
        public void DeleteArtWork(int id)
        {
            ArtWork artWork = _artWorks.FirstOrDefault(x => x.Id == id);
            _artWorks.Remove(artWork);
            _context.SaveChanges();


        }
    }
}
