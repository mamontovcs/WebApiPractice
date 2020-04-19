using DAL.Models;
using System;

namespace DAL.Repository
{
    internal class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly AgencyContext _agencyContext;

        public IGenericRepository<Role> Roles { get; set; }
        public IGenericRepository<User> Users { get; set; }
        public IGenericRepository<Service> Services { get; set; }

        private bool Disposed;


        public UnitOfWork(AgencyContext agencyContext, IGenericRepository<Role> roles, IGenericRepository<User> users, IGenericRepository<Service> services)
        {
            _agencyContext = new AgencyContext();
            Roles = roles;
            Users = users;
            Services = services;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (Disposed) return;
            if (disposing)
            {
                _agencyContext.Dispose();
            }

            Disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            _agencyContext.SaveChanges();
        }
    }
}
