using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using UserManagementDummy.Data;
using UserManagementDummy.Models;

namespace UserManagementDummy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]

    public class LoginController : ControllerBase
    {
        private readonly ApplicationContext context;

        public LoginController(ApplicationContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public async Task<ActionResult<User>> Login(int? id, string password)
        {
            if (!id.HasValue || string.IsNullOrEmpty(password))
            {
                return BadRequest("Invalid input. Both ID and password are required.");
            }

            var user = await context.Users.Where(u => u.ID == id).FirstOrDefaultAsync();

            if (user == null)
            {
                return NotFound($"User with ID {id} not found.");
            }

            if (!ValidatePassword(user, password))
            {
                return Unauthorized("Invalid password.");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(key);
            }
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.FirstName.ToString()),
                    new Claim(ClaimTypes.Email, user.Email.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new { user, Token = tokenString });
        }

        private bool ValidatePassword(User user, string password)
        {
            return user.Password == password;
        }
    }
}
