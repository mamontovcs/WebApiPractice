namespace DAL.Models
{
    /// <summary>
    /// Data transfer object for <see cref="Role"/>
    /// </summary>
    public class RoleDto
    {
        /// <summary>
        /// Role identifier
        /// </summary>
        public int RoleID { get; set; }

        /// <summary>
        /// Role name
        /// </summary>
        public string RoleName { get; set; }
    }
}
