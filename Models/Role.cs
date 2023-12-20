using System.ComponentModel.DataAnnotations;

namespace UserManagementDummy.Models
{
    
    public class Role
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Permissions { get; set; }

       public List<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}
