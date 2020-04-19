using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("Roles")]
    public class Role
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
    }
}
