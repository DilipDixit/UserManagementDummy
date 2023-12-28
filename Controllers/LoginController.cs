using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
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
        private IConfiguration _config;

        public LoginController(ApplicationContext context, IConfiguration config)
        {
            this.context = context;
            _config = config;
        }

        [HttpPost]
        public async Task<ActionResult<User>> Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return BadRequest("Invalid input. Both ID and password are required.");
            }

            var user = await context.Users.Where(u => u.Email== email).FirstOrDefaultAsync();

            if (user == null)
            {
                return NotFound($"User with ID {email} not found.");
            }

            if (!ValidatePassword(user, password))
            {
                return Unauthorized("Invalid password.");
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var Sectoken = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);

            return Ok(token);
        }

        #region validate password
        private bool ValidatePassword(User user, string password)
        {
            return user.Password == password;
        }
        #endregion
    }
}
