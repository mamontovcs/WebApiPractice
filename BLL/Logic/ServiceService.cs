using AutoMapper;
using DAL.Dependencies;
using DAL.Models;
using DAL.Repository;
using Ninject;
using System.Collections.Generic;

namespace BLL.Logic
{
    internal class ServiceService : IServiceService
    {
        private readonly IUnitOfWork unitOfWork;

        private IMapper serviceMapper;

        public ServiceService()
        {
            serviceMapper = new MapperConfiguration(cfg => cfg.CreateMap<Service, MService>()).CreateMapper();
            unitOfWork = new StandardKernel(new DataAccessModule()).Get<IUnitOfWork>();
        }

        public bool AddService(MService mService)
        {
            unitOfWork.Services.Create(new Service { Name = mService.Name, Price = mService.Price, Type = mService.Type });
            unitOfWork.Save();

            return true;
        }

        public bool BuyService(int userId, int serviceId)
        {
            var user = unitOfWork.Users.FindById(userId);

            var service = unitOfWork.Services.FindById(serviceId);

            if (user != null && service != null)
            {
                user.Services.Add(service);
                service.UsersWhoBought.Add(user);
                unitOfWork.Save();
                return true;
            }
            else
            {
                return false;
            }
        }

        public MService GetServiceByID(int id)
        {
            return serviceMapper.Map<Service, MService>(unitOfWork.Services.GetOne(x => (x.ServiceID == id)));
        }

        public ICollection<MService> GetServices()
        {
            unitOfWork.Services.Create(new Service { Name = "A", Price = "500", Type = "Type" });
            unitOfWork.Save();

            return serviceMapper.Map<IEnumerable<Service>, List<MService>>(unitOfWork.Services.Get());
        }

        public bool RemoveServiceByID(int id)
        {
            unitOfWork.Users.Remove(unitOfWork.Users.FindById(id));
            unitOfWork.Save();
            return true;
        }
    }
}
