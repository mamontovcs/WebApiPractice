using DAL;
using DAL.Dependencies;
using DAL.Models;
using DAL.Repository;
using Ninject;
namespace StartDataBase
{
    class Program
    {
        static void Main(string[] args)
        {
            var kernel = new StandardKernel(new DataAccessModule());

            var dataBase = kernel.Get<IUnitOfWork>();

            AgencyContext data = new AgencyContext();

            data.Roles.Add(new Role { RoleName = "Admin" });
            data.Roles.Add(new Role { RoleName = "Admin" });
            data.Roles.Add(new Role { RoleName = "Admin" });
            data.Roles.Add(new Role { RoleName = "Admin" });
            data.SaveChanges();

            dataBase.Roles.Create(new Role { RoleName = "Admin" });
            dataBase.Roles.Create(new Role { RoleName = "Manager" });
            dataBase.Roles.Create(new Role { RoleName = "User" });
            dataBase.Roles.Create(new Role { RoleName = "Guest" });
            dataBase.Save();

            dataBase.Users.Create(new User { Login = "Admin", Pass = "Admin", RoleId = 1 });
            dataBase.Users.Create(new User { Login = "Manager", Pass = "Manager", RoleId = 2 });
            dataBase.Users.Create(new User { Login = "User", Pass = "User", RoleId = 3 });
            dataBase.Users.Create(new User { Login = "Guest", Pass = "Guest", RoleId = 4 });
            dataBase.Save();


            dataBase.Services.Create(new Service { Name = "CarWash", Price = "200", Type = "DOM" });
            dataBase.Save();


        }
    }
}
