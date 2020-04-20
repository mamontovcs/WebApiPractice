using AutoMapper;
using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using BLL.DTO;

namespace BLL.Logic
{
    /// <summary>
    /// Service for agency services
    /// </summary>
    internal class ServiceService : IServiceService
    {
        /// <summary>
        /// Maintains a list of objects affected by a business transaction and coordinates the writing out of changes
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Transforms an input object of one type into an output object of a different type
        /// </summary>
        private IMapper _serviceMapper;

        /// <summary>
        /// Creates instance of <see cref="ServiceService"/>
        /// </summary>
        public ServiceService(IUnitOfWork unitOfWork)
        {
            _serviceMapper = new MapperConfiguration(cfg => cfg.CreateMap<Service, ServiceDto>()).CreateMapper();
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Adds service to database
        /// </summary>
        /// <param name="serviceDto">Service which will be added</param>
        public void AddService(ServiceDto serviceDto)
        {
            try
            {
                _unitOfWork.Services.Create(new Service { Name = serviceDto.Name, Price = serviceDto.Price, Type = serviceDto.Type });
                _unitOfWork.Save();
            }
            catch (Exception exception)
            {
                throw new Exception("Data can not be added!" + $"/n{exception.Message}");
            }
        }

        /// <summary>
        /// Provides logic for buying service
        /// </summary>
        /// <param name="userId">User identifier</param>
        /// <param name="serviceId">Service identifier</param>
        /// <returns></returns>
        public bool BuyService(int userId, int serviceId)
        {
            var user = _unitOfWork.Users.FindById(userId);

            var service = _unitOfWork.Services.FindById(serviceId);

            if (user != null && service != null)
            {
                user.Services.Add(service);
                service.UsersWhoBought.Add(user);
                _unitOfWork.Save();
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Gets service by it's Id
        /// </summary>
        /// <param name="id">Service identifier</param>
        /// <returns>Service with corresponding identifier</returns>
        public ServiceDto GetServiceByID(int id)
        {
            return _serviceMapper.Map<Service, ServiceDto>(_unitOfWork.Services.GetOne(x => (x.ServiceId == id)));
        }

        /// <summary>
        /// Gets all services from database
        /// </summary>
        /// <returns>All services from database</returns>
        public ICollection<ServiceDto> GetServices()
        {
            return _serviceMapper.Map<IEnumerable<Service>, List<ServiceDto>>(_unitOfWork.Services.Get());
        }

        /// <summary>
        /// Removes sevices from database
        /// </summary>
        /// <param name="id">Service identifier</param>
        public void RemoveServiceByID(int id)
        {
            try
            {
                _unitOfWork.Users.Remove(_unitOfWork.Users.FindById(id));
                _unitOfWork.Save();
            }
            catch (Exception exception)
            {
                throw new Exception("Data can not be removed!" + $"/n{exception.Message}");

            }
        }
    }
}
