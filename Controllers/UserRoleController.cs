using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using System.Data.Entity;
using UserManagementDummy.Data;
using Microsoft.EntityFrameworkCore;
using UserManagementDummy.Models;
using Microsoft.AspNetCore.Identity;

namespace UserManagementDummy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private readonly ApplicationContext context;

        public UserRoleController(ApplicationContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<IEnumerable<UserRole>> GetUserRoles()
        {
            var data = await context.UserRoles.Where(ur => (bool)!ur.IsDeleted).ToListAsync();
            return data;
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<UserRole>> GetUserRoleByID(int Id)
        {
            var data = await context.UserRoles.Where(x => x.ID == Id).Where(x => x.IsDeleted==false).SingleOrDefaultAsync();
            if (data == null)
            {
                return NotFound($"Error: There is no non-deleted record with UserRoleID: {Id}");
            }

            return Ok(data);
        }


        [HttpPost]
        public async Task<ActionResult<UserRole>> AddUserRole(UserRole userRole)
        {
            if (userRole == null)
            {
                return BadRequest("Error: Invalid request data");
            }

            if (userRole.RoleID == 0)
            {
                ModelState.AddModelError("RoleId", "Error: RoleId should not be zero.");
                return BadRequest(ModelState);
            }

            var existingUserRole = await context.UserRoles
                .FirstOrDefaultAsync(ur => ur.UserID == userRole.UserID && ur.RoleID == userRole.RoleID);

            if (existingUserRole != null)
            {
                return BadRequest("Error: You cannot give the same role to the same user!");
            }

            context.UserRoles.Add(userRole);
            await context.SaveChangesAsync();
            return Ok(userRole);
        }


        [HttpPut("{Id}")]
        public async Task<ActionResult<UserRole>> UpdateUserRole(int Id, int roleId)
        {
            if (roleId == 0)
            {
                return BadRequest("Error: Invalid roleId");
            }

            var existingUserRole = await context.UserRoles.FindAsync(Id);

            if (existingUserRole == null)
            {
                return NotFound($"Error: There is no record with UserRoleID: {Id}");
            }

            existingUserRole.RoleID = roleId;

            context.Entry(existingUserRole).State = EntityState.Modified;

            await context.SaveChangesAsync();

            return Ok(existingUserRole);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<UserRole>> DeleteUserRole(int Id)
        {
            var userRoleToDelete = await context.UserRoles.FindAsync(Id);

            if (userRoleToDelete == null)
            {
                return NotFound($"Error: No record found with UserRoleID: {Id}");
            }

            if ((bool)userRoleToDelete.IsDeleted)
            {
                return BadRequest($"Error: The record with UserRoleID {Id} has already been deleted.");
            }

            userRoleToDelete.IsDeleted = true;
            userRoleToDelete.DeletedAt = DateTime.UtcNow;
            userRoleToDelete.DeletedFromIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();

            context.Entry(userRoleToDelete).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return Ok(userRoleToDelete);
        }

    }
}