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
            serviceMapper = new MapperConfiguration(cfg => cfg.CreateMap<Service, ServiceDto>()).CreateMapper();
            unitOfWork = new StandardKernel(new DataAccessModule()).Get<IUnitOfWork>();
        }

        public bool AddService(ServiceDto ServiceDto)
        {
            unitOfWork.Services.Create(new Service { Name = ServiceDto.Name, Price = ServiceDto.Price, Type = ServiceDto.Type });
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

        public ServiceDto GetServiceByID(int id)
        {
            return serviceMapper.Map<Service, ServiceDto>(unitOfWork.Services.GetOne(x => (x.ServiceID == id)));
        }

        public ICollection<ServiceDto> GetServices()
        {
            unitOfWork.Services.Create(new Service { Name = "A", Price = "500", Type = "Type" });
            unitOfWork.Save();

            return serviceMapper.Map<IEnumerable<Service>, List<ServiceDto>>(unitOfWork.Services.Get());
        }

        public bool RemoveServiceByID(int id)
        {
            unitOfWork.Users.Remove(unitOfWork.Users.FindById(id));
            unitOfWork.Save();
            return true;
        }
    }
}
