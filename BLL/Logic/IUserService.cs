using DAL.Models;
using System.Collections.Generic;

namespace BLL.Logic
{
    /// <summary>
    /// Service for agency users
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Gets all users from database
        /// </summary>
        /// <returns>All services from database</returns>
        ICollection<UserDto> GetUsers();

        /// <summary>
        /// Gets user by his Id
        /// </summary>
        /// <param name="id">User identifier</param>
        /// <returns></returns>
        UserDto GetUserByID(int id);

        /// <summary>
        /// Adds user to database
        /// </summary>
        /// <param name="userDto">User which will be added</param>
        void AddUser(UserDto userDto);

        /// <summary>
        /// Removes user from database
        /// </summary>
        /// <param name="id">User identifier</param>
        void RemoveUserByID(int id);
    }
}
