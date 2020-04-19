using DAL.Models;
using System.Data.Entity;

namespace DAL
{
    public class AgencyContext : DbContext
    {
        public AgencyContext() : base("name=AgencyDatabase")
        {
            this.Configuration.AutoDetectChangesEnabled = false;
        }

        public DbSet<Role> Roles { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Service> Services { get; set; }
    }
}
