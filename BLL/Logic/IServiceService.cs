using DAL.Models;
using System.Collections.Generic;
using BLL.DTO;

namespace BLL.Logic
{
    /// <summary>
    /// Service for agency services
    /// </summary>
    public interface IServiceService
    {
        /// <summary>
        /// Gets all services from database
        /// </summary>
        /// <returns>All services from database</returns>
        ICollection<ServiceDto> GetServices();

        /// <summary>
        /// Gets service by it's Id
        /// </summary>
        /// <param name="id">Service identifier</param>
        /// <returns></returns>
        ServiceDto GetServiceByID(int id);

        /// <summary>
        /// Adds service to database
        /// </summary>
        /// <param name="serviceDto">Service which will be added</param>
        void AddService(ServiceDto serviceDto);

        /// <summary>
        /// Removes sevices from database
        /// </summary>
        /// <param name="id">Service identifier</param>
        void RemoveServiceByID(int id);

        /// <summary>
        /// Provides logic for buying service
        /// </summary>
        /// <param name="userId">User identifier</param>
        /// <param name="serviceId">Service identifier</param>
        /// <returns></returns>
        bool BuyService(int userId, int serviceId);
    }
}
