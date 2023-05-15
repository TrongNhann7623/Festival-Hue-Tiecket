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
    public class RolesController : ControllerBase
    {
        private readonly MyDbContext _context;
        public RolesController(MyDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var role = _context.roles.ToList();
            return Ok(role);
        }
        [HttpGet("{RolesID}")]
        public IActionResult GetByID(string RolesID)
        {
            try
            {
                var role = _context.roles.SingleOrDefault(RL => RL.RolesID == int.Parse(RolesID));
                if (role == null)
                {
                    return NotFound();
                }
                return Ok(role);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult CreateNew(RolesModels model)
        {
            try
            {
                var role = new Roles
                {
                    Name = model.Name,
                    
                };
                _context.Add(role);
                _context.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{RolesID}")]
        public IActionResult UpdateRolesByID(int RolesID, RolesModels model)
        {
            var role = _context.roles.SingleOrDefault(RL => RL.RolesID== RolesID);
            if (role != null)
            {
                role.Name = model.Name;
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
        [HttpDelete("{RolesID}")]
        public async Task<IActionResult> DeleteRolesByID(int ID)
        {
            var role = await _context.roles.FindAsync(ID);
            if (role != null)
            {
                _context.roles.Remove(role);
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
