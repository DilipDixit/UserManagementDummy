namespace UserManagementDummy.Models
{
    public class User
    {

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public bool? isDeleted { get; set; }
        public DateTime? DeleteAt { get; set; }
        public string? DeleteFromIpAddress { get; set; }

        public List<UserRole> UserRoles { get; set; } = new List<UserRole>();

    }
}