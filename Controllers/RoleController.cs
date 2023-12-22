using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Use EF Core namespace
using UserManagementDummy.Data;
using UserManagementDummy.Models;

namespace UserManagementDummy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public RoleController(ApplicationContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IEnumerable<Role>> GetRoles()
        {
            var roles = await _context.Roles.ToListAsync();
            return roles;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> GetRole(int id)
        {
            try
            {
                var Role = await _context.Roles.FindAsync(id);
                if (Role == null)
                {
                    return NotFound($"Role with ID {id} not found.");
                }
                return Role;
            }
            catch (Exception Ex)
            {
                return StatusCode(500, $"An error occurred: {Ex.Message}");
            }
        }
        [HttpPost]
        public async Task<ActionResult<Role>> PostRole(Role role)
        {
            if (role == null)
            {
                return BadRequest("Role Object is null");
            }
            var exitingRole = await _context.Roles.FirstOrDefaultAsync(r => r.Name == role.Name);
            if (exitingRole != null)
            {
                return BadRequest("This Role is alrady added");
            }
            role.UserRoles = null;

            _context.Roles.Add(role);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Role>> EditRole(int id, Role updatedRole)
        {
            try
            {
                var ExitingRole = await _context.Roles.FindAsync(id);
                if (updatedRole == null)
                {
                    return NotFound($"There is no Role Like {updatedRole}");
                }
                ExitingRole.Name = updatedRole.Name;
                ExitingRole.Permissions = updatedRole.Permissions;

                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"An error occurred: {ex.Message}" });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Role>> DeleteRole(int id)
        {
            var Role = await _context.Roles.FindAsync(id);
            if (Role == null)
            {
                return NotFound($"There is no id like {id}");
            }
            _context.Remove(Role);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
