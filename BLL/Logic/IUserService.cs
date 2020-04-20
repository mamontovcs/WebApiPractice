using DAL.Models;
using System.Collections.Generic;

namespace BLL.Logic
{
    public interface IUserService
    {
        ICollection<UserDto> GetUsers();

        UserDto GetUserByID(int id);

        bool AddUser(UserDto newuser);

        bool RemoveUserByID(int id);
    }
}
