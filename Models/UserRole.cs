using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace UserManagementDummy.Models
{
    public class UserRole
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public User User { get; set; } = null!;

        public int RoleID { get; set; }
        public Role Role { get; set; } = null!;
    }
}
