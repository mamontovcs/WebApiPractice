using BLL.Logic;
using Ninject.Modules;

namespace BLL.Dependencies
{
    /// <summary>
    /// A loadable unit that defines bindings of business logic layer
    /// </summary>
    public class BusinessLogicModule : NinjectModule
    {
        /// <summary>
        ///  Loads the module into the kernel
        /// </summary>
        public override void Load()
        {
            Bind<IServiceService>().To<ServiceService>();
            Bind<IUserService>().To<UserService>();
        }
    }
}
