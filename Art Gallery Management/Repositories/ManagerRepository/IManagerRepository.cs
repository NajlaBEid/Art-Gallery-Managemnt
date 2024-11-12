using Art_Gallery_Management.Models.Managers;

namespace Art_Gallery_Management.Repositories.ManagerRepository
{
    public interface IManagerRepository
    {
        Manager GetManagerById(int id);
        Manager CreateManager(Manager manager);
        Manager UpdateManager(Manager manager,int id);
        void DeleteManager(int id);
    }
}
