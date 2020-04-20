using BLL.Dependencies;
using BLL.Logic;
using Ninject;
using System.Collections.Generic;
using System.Web.Http;
using BLL.DTO;

namespace Course_6.Controllers
{
    public class ServiceController : ApiController
    {
        // GET: api/Service
        public IEnumerable<ServiceDto> Get()
        {

            var kernel = new StandardKernel(new BusinessLogicModule());
            var service = kernel.Get<IServiceService>();

            service.AddService(new ServiceDto(){Name = "First"});
            service.AddService(new ServiceDto() { Name = "First" });
            service.AddService(new ServiceDto() { Name = "First" });

            var test = service.GetServices();

            return service.GetServices();
        }

        // GET: api/Service/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Service
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Service/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Service/5
        public void Delete(int id)
        {
        }
    }
}
