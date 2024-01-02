using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using UserManagementDummy.Data;
using UserManagementDummy.Models;

namespace Prac.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly ILogger<UsersController> logger;

        public UsersController(ApplicationContext context,ILogger<UsersController>logger)
        {
            _context = context;
            this.logger = logger;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            logger.LogInformation("all the User are gettings");
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                logger.LogWarning("User with ID: {UserId} not found.", id);
                return NotFound();
            }

            return user;
        }
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {

            logger.LogInformation("Create the new User");
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return NoContent();

            //return CreatedAtAction("GetUser", new { id = user.ID }, user);
        }
        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            logger.LogInformation("Invalid data provided to this id");
            if (user == null)
            {
                return BadRequest();
            }

            var existingUser = await _context.Users.FindAsync(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;

            await _context.SaveChangesAsync();
            return NoContent();
        }


        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.ID == id);
        }


        //Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            logger.LogInformation("Deleted the User");
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExist(int id)
        {
            return _context.Users.Any(e => e.ID == id);
        }

    }
}


