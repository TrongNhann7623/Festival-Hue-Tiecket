using Festival_Hue_Tiecket.Data;
using Festival_Hue_Tiecket.Modelsss;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Festival_Hue_Tiecket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly MyDbContext _context;
        public UsersController(MyDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var user = _context.users.ToList();
            return Ok(user);
        }
        [HttpGet("{UserID}")]
        public IActionResult GetByUsersID(string UserID)
        {
            try
            {
                var user = _context.users.SingleOrDefault(US => US.UserID == int.Parse(UserID));
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult CreateNew(UsersModels model)
        {
            try
            {
                var user = new Users
                {
                    UserName = model.UserName,
                    Password = model.Password,
                    Email = model.Email,
                    SDT = model.SDT,
                    Roles = model.Roles,                   
                };
                _context.Add(user);
                _context.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{UserID}")]
        public IActionResult UpdateUsersByID(int UserID, UsersModels model)
        {
            var user = _context.users.SingleOrDefault(US => US.UserID == UserID);
            if (user != null)
            {
                user.UserName = model.UserName;
                user.Password = model.Password;
                user.Email = model.Email;
                user.SDT = model.SDT;
                user.Roles = model.Roles;
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
        [HttpDelete("{UserID}")]
        public async Task<IActionResult> DeleteUsesByID(int UserID)
        {
            var user = await _context.users.FindAsync(UserID);
            if (user != null)
            {
                _context.users.Remove(user);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
