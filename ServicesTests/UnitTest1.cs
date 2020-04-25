using BLL.Logic;
using DAL.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using BLL.DTO;
using System.Linq;
using DAL.Models;
using DAL;
using System.Collections.Generic;
using System.Data.Entity;

namespace ServicesTests
{
    [TestClass]
    public class UnitTest1
    {
        private IServiceService _serviceService;

        private IUnitOfWork _unitOfWork;

        [TestInitialize]
        public void Initialize()
        {
            var kek = Substitute.For<DbSet<Service>, IQueryable<Service>>();
            var ag = Substitute.For<AgencyContext>();
            ag.Services = kek;



            _unitOfWork = Substitute.For<UnitOfWork>(ag, Substitute.For<IGenericRepository<Role>>() ,
                Substitute.For<IGenericRepository<User>>() , Substitute.For<IGenericRepository<Service>>());
            _serviceService = new ServiceService(_unitOfWork);
        }


        [TestMethod]
        public void TestMethod1()
        {
            _serviceService.AddService(new ServiceDto());

            Assert.AreEqual(1, _unitOfWork.Services.Get().Count());
        }
    }
}
