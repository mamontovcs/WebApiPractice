using System.Collections.Generic;

namespace DAL.Models
{
    public class MUser
    {
        public int UserID { get; set; }

        public string Name { get; set; }

        public string Login { get; set; }

        public string Pass { get; set; }

        public int RoleId { get; set; }

        public virtual Role Role { get; set; }

        public virtual ICollection<Service> Services { get; set; }
    }
}
