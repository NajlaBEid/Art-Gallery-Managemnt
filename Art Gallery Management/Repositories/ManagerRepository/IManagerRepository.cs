using Art_Gallery_Management.Models.Managers;

namespace Art_Gallery_Management.Repositories.ManagerRepository
{
    public interface IManagerRepository
    {
        Task<Manager> GetManagerById(int id);
        Task<Manager> CreateManager(Manager manager);
        Task<Manager> UpdateManager(Manager manager,int id);
        Task<Manager> DeleteManager(Manager manager);
    }
}
