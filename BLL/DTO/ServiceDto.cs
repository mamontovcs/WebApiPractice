using System.Collections.Generic;

namespace DAL.Models
{
    /// <summary>
    /// Data transfer object for <see cref="Service"/>
    /// </summary>
    public class ServiceDto
    {
        /// <summary>
        /// Service identifier
        /// </summary>
        public int ServiceID { get; set; }

        /// <summary>
        /// Service name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Service type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Service price
        /// </summary>
        public string Price { get; set; }

        /// <summary>
        /// Collection of users who bought this service
        /// </summary>
        public virtual ICollection<User> UsersWhoBought { get; set; }
    }
}
