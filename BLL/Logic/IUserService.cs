using DAL.Models;
using System.Collections.Generic;

namespace BLL.Logic
{
    public interface IUserService
    {
        ICollection<MUser> GetUsers();

        MUser GetUserByID(int id);

        bool AddUser(MUser newuser);

        bool RemoveUserByID(int id);
    }
}
