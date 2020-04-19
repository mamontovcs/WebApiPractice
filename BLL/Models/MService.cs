using System.Collections.Generic;

namespace DAL.Models
{
    public class MService
    {
        public int ServiceID { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Price { get; set; }

        public virtual ICollection<User> UsersWhoBought { get; set; }
    }
}
