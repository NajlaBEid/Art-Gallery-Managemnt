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
        public Manager CreateManager(Manager manager)
        {
            _managers.Add(manager);
            _context.SaveChanges();
            return manager;
        }

        public void DeleteManager(int id)
        {
            Manager  manager = _managers.FirstOrDefault(a => a.Id == id);
            _managers.Remove(manager);
            _context.SaveChanges();
        }

        public Manager GetManagerById(int id)
        {
            return _managers.Find(id);
        }

        public Manager UpdateManager(Manager manager, int id)
        {
            _managers.Update(manager);
            _context.SaveChanges();
            return manager;
        }
    }
}
