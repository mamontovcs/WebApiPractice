using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Logic
{
    public interface IServiceService
    {
        ICollection<MService> GetServices();

        MService GetServiceByID(int id);

        bool AddService(MService mService);

        bool RemoveServiceByID(int id);

        bool BuyService(int userId, int serviceId);
    }
}
