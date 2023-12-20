using Microsoft.EntityFrameworkCore;
using UserManagementDummy.Models;

namespace UserManagementDummy.Data
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            
        }
        public DbSet<UserRole> UserRols { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
