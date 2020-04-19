using DAL.Models;

namespace DAL.Repository
{
    public interface IUnitOfWork
    {
        IGenericRepository<Role> Roles { get; set; }
        IGenericRepository<User> Users { get; set; }
        IGenericRepository<Service> Services { get; set; }

        void Save();
        void Dispose();
    }
}
