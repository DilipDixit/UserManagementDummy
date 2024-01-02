namespace UserManagementDummy.Models
{
    public class UserRole
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public User User { get; set; } = null!;

        public int RoleID { get; set; }
        public Role Role { get; set; } = null!;
        public bool? IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string? DeletedFromIpAddress { get; set; }
    }
}
