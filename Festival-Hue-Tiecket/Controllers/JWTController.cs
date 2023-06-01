using Festival_Hue_Tiecket.Data;
using Festival_Hue_Tiecket.Modelsss;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace Festival_Hue_Tiecket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JWTController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly MyDbContext _context;
        public JWTController(MyDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        [HttpPost]
        public IActionResult Post(Users users)
        {
            if (users != null && users.SDT != null && users.Password != null)
            {
                //var userData = await GetUser(account.Phone, account.Password);
                var jwt = _configuration.GetSection("Jwt").Get<JwtHeaderParameterNames>();
                if (users != null)
                {
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserID", users.UserID.ToString()),
                        new Claim("Name", users.UserName),
                        new Claim("Password", users.Password),
                        new Claim("Email", users.Email),
                        new Claim("sdt", users.SDT),


                    };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                            _configuration["Jwt:Issuer"],
                            _configuration["Jwt:Audience"],
                            claims,
                            expires: DateTime.Now.AddMinutes(20),
                            signingCredentials: signIn
                        );
                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid");
                }
            }
            else
            {
                return BadRequest("Invalid");
            }
        }
        [HttpGet]
        public async Task<Users> GetUser(string sdt, string password)
        {
            Users user = await _context.Users.FirstOrDefaultAsync(u => u.SDT == sdt);

            if (user != null && BC.Verify(password, user.Password))
            {
                return user;
            }

            return null;
        }
        [HttpPost("fPassword")]
        public async Task<IActionResult> ForgotPassword(string phoneNumber)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.SDT == phoneNumber);
            if (user == null)
            {
                return BadRequest("User not found");
            }

            
            user.ResetTokenExpires = DateTime.Now.AddDays(1);
            await _context.SaveChangesAsync();
            return Ok(user.PasswordResetToken);
        }

        [HttpPost("rPassword")]
        public async Task<IActionResult> ResetPassword(Resetpassword request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.PasswordResetToken == request.Token);
            if (user == null || user.ResetTokenExpires < DateTime.Now)
            {
                return BadRequest("User not found");
            }

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);
            user.Password = hashedPassword;

            await _context.SaveChangesAsync();
            return Ok("Done");
        }
    }
}
