using System.Collections.Generic;
using AutoMapper;
using BLL.DTO;
using DAL.Models;
using DAL.Repository;

namespace BLL.Logic
{
    /// <summary>
    /// Service for agency users
    /// </summary>
    internal class UserService : IUserService
    {
        /// <summary>
        /// Maintains a list of objects affected by a business transaction and coordinates the writing out of changes
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Transforms an input object of one type into an output object of a different type
        /// </summary>
        private readonly IMapper _userMapper;

        /// <summary>
        ///  Creates instance of <see cref="UserService"/>
        /// </summary>
        /// <param name="unitOfWork">Maintains a list of objects affected by a business
        /// transaction and coordinates the writing out of changes</param>
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userMapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDto>()).CreateMapper();
        }

        /// <summary>
        /// Adds user to database
        /// </summary>
        /// <param name="userDto">User which will be added</param>
        public void AddUser(UserDto userDto)
        {
            _unitOfWork.Users.Create(new User { Name = userDto.Name, Login = userDto.Login, Pass = userDto.Pass, RoleId = userDto.RoleId });
            _unitOfWork.Save();
        }

        /// <summary>
        /// Gets user by his Id
        /// </summary>
        /// <param name="id">User identifier</param>
        /// <returns></returns>
        public UserDto GetUserByID(int id)
        {
            return _userMapper.Map<User, UserDto>(_unitOfWork.Users.GetOne(x => (x.UserId == id)));
        }

        /// <summary>
        /// Gets all users from database
        /// </summary>
        /// <returns>All services from database</returns>
        public ICollection<UserDto> GetUsers()
        {
            return _userMapper.Map<IEnumerable<User>, List<UserDto>>(_unitOfWork.Users.Get());
        }

        /// <summary>
        /// Removes user from database
        /// </summary>
        /// <param name="id">User identifier</param>
        public void RemoveUserByID(int id)
        {
            _unitOfWork.Users.Remove(_unitOfWork.Users.FindById(id));
            _unitOfWork.Save();
        }
    }
}
