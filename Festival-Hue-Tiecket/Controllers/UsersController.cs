using Festival_Hue_Tiecket.Data;
using Festival_Hue_Tiecket.Modelsss;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using BC = BCrypt.Net.BCrypt;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;

namespace Festival_Hue_Tiecket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly MyDbContext _context;
        public IConfiguration _configuration;
        public UsersController(MyDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> Account()
        {
            if (_context.Users == null)
            {
                return BadRequest("Something wrong");
            }
            return await _context.Users.ToListAsync();
        }
        [HttpGet("{UserID}")]
        public ActionResult<Users> GetAccount(int UserID)
        {
            var US = _context.Users.Include(x => x.UserID).SingleOrDefault(x => x.UserID == UserID);
            if (US != null)
            {
                var lsThongTin = _context
                    .TicketCheckins
                    .Include(x => x.TicketID)
                    .AsNoTracking()
                    .Where(x => x.TicketID == US.UserID)
                    .OrderByDescending(x => x.UserID)
                    .ToList();
                return Ok(US);
            }
            return BadRequest("Something wrong");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccount(int UserID, Users users)
        {
            if (UserID != users.UserID)
            {
                return BadRequest();
            }

            _context.Entry(users).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountExists(UserID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        [HttpPost("Register")]
        public async Task<ActionResult<Users>> PostAccount(Users users)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'DataContext.Accounts'  is null.");
            }
            users.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(users.Password);
            _context.Users.Add(users);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccount", new { id = users.UserID }, users);
        }
        [HttpGet("Login")]
        public async Task<Users> Login(string SDT, string password)
        {
            Users ac = await _context.Users.FirstOrDefaultAsync(u => u.SDT == SDT);
            if (ac != null && BCrypt.Net.BCrypt.Verify(password, ac.Password))
            {
                return ac;
            }
            return null;
        }
        [HttpPost("fPassword")]
        public async Task<IActionResult> ForgotPassword(String SDT)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.SDT == SDT);
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

            string hashedPassword = BC.HashPassword(request.Password);
            user.Password = hashedPassword;

            await _context.SaveChangesAsync();
            return Ok("Done");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var account = await _context.Users.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }

            _context.Users.Remove(account);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AccountExists(int id)
        {
            return (_context.Users?.Any(e => e.UserID == id)).GetValueOrDefault();
        }      
    }
}
