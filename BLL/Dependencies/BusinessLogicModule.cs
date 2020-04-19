using BLL.Logic;
using Ninject.Modules;

namespace BLL.Dependencies
{
    public class BusinessLogicModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IServiceService>().To<ServiceService>();
            Bind<IUserService>().To<UserService>();
        }
    }
}
