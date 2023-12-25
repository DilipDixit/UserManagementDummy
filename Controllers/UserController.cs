using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using UserManagementDummy.Data;
using UserManagementDummy.Models;

namespace Prac.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public UsersController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {


            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return NoContent();

            //return CreatedAtAction("GetUser", new { id = user.ID }, user);
        }
        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {

            var exitingUser = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            exitingUser.FirstName=user.FirstName;
            exitingUser.LastName=user.LastName;
            exitingUser.Email=user.Email;
            exitingUser.Password=user.Password;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool UserExists(int id)
        {
            throw new NotImplementedException();
        }

        //Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
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


