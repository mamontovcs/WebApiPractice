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
        public bool AddUser(MUser newuser)
        {
            throw new NotImplementedException();
        }

        public MUser GetUserByID(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<MUser> GetUsers()
        {
            throw new NotImplementedException();
        }

        public bool RemoveUserByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
