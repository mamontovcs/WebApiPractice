using DAL.Models;
using DAL.Repository;
using Ninject.Modules;

namespace DAL.Dependencies
{
    public class DataAccessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IGenericRepository<User>>().To<AgencyRepository<User>>();
            Bind<IGenericRepository<Role>>().To<AgencyRepository<Role>>();
            Bind<IGenericRepository<Service>>().To<AgencyRepository<Service>>();

            Bind<IUnitOfWork>().To<UnitOfWork>();

        }
    }
}
