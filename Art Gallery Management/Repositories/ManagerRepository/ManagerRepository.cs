using Art_Gallery_Management.Data;
using Art_Gallery_Management.Models.Artists;
using Art_Gallery_Management.Models.Managers;
using Microsoft.EntityFrameworkCore;

namespace Art_Gallery_Management.Repositories.ManagerRepository
{
    public class ManagerRepository : IManagerRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly DbSet<Manager> _managers;

        public ManagerRepository(ApplicationDbContext context)
        {
            _context = context;
            _managers = context.Set<Manager>();
        }
        public async Task<Manager> CreateManager(Manager manager)
        {
            _managers.Add(manager);
            _context.SaveChanges();
            return manager;
        }

        public  async Task<Manager> DeleteManager(Manager manager)
        {
            
            _managers.Remove(manager);
            await _context.SaveChangesAsync();
            return manager;
        }

        public async Task<Manager> GetManagerById(int id)
        {
            return _managers.Find(id);
        }

        public async Task<Manager> UpdateManager(Manager manager, int id)
        {
            _managers.Update(manager);
            _context.SaveChanges();
            return manager;
        }
    }
}
