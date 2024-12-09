using Art_Gallery_Management.Data;
using Art_Gallery_Management.Models.Exhibitions;
using Art_Gallery_Management.Models.Managers;
using Microsoft.EntityFrameworkCore;

namespace Art_Gallery_Management.Repositories.ExhibitionRepository
{
    public class ExhibitionRepository : IExhibitionRepository
    {
        private readonly ApplicationDbContext _context;
            private readonly DbSet<Exhibition> _exhibitions;

        public ExhibitionRepository(ApplicationDbContext context)
        {
            _context = context;
            _exhibitions = context.Set<Exhibition>();
        }

        public async Task<Exhibition> CreateExhibition(Exhibition exhibition)
        {
           await _exhibitions.AddAsync(exhibition);
           await _context.SaveChangesAsync();
            return exhibition;
        }


        public async Task<Exhibition> GetExhibitionById(int id)
        {
            return await _exhibitions.FindAsync(id);
        }

        public async Task<Exhibition> UpdateExhibiton(Exhibition exhibition, int id)
        {
            _exhibitions.Update(exhibition);
            await _context.SaveChangesAsync();
            return exhibition;
        }
        public async Task<Exhibition> DeleteExhibition(Exhibition exhibition)
        {
            _exhibitions.Remove(exhibition);
            await _context.SaveChangesAsync();
            return exhibition;
           

        }
    }
}
