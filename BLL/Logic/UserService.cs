using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace BLL.Logic
{
    internal class UserService : IUserService
    {
        public bool AddUser(UserDto newuser)
        {
            throw new NotImplementedException();
        }

        public UserDto GetUserByID(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<UserDto> GetUsers()
        {
            throw new NotImplementedException();
        }

        public bool RemoveUserByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
