using Festival_Hue_Tiecket.Data;
using Festival_Hue_Tiecket.Modelsss;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        // GET: api/Roles

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RolesModels>>> GetRoles()
        {
            if (_context.Roles == null)
            {
                return NotFound();
            }
            return await _context.Roles.ToListAsync();
        }

        // GET: api/Roles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RolesModels>> GetRoles(int id)
        {
            if (_context.Roles == null)
            {
                return NotFound();
            }
            var roles = await _context.Roles.FindAsync(id);

            if (roles == null)
            {
                return NotFound();
            }

            return roles;
        }

        // PUT: api/Roles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoles(int id, RolesModels roles)
        {
            if (id != roles.RolesID)
            {
                return BadRequest();
            }

            _context.Entry(roles).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RolesExists(id))
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

        // POST: api/Roles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RolesModels>> PostRoles(RolesModels roles)
        {
            if (_context.Roles == null)
            {
                return Problem("Entity set 'DataContext.Roles'  is null.");
            }
            _context.Roles.Add(roles);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoles", new { id = roles.RolesID }, roles);
        }

        // DELETE: api/Roles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoles(int id)
        {
            if (_context.Roles == null)
            {
                return NotFound();
            }
            var roles = await _context.Roles.FindAsync(id);
            if (roles == null)
            {
                return NotFound();
            }

            _context.Roles.Remove(roles);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RolesExists(int id)
        {
            return (_context.Roles?.Any(e => e.RolesID == id)).GetValueOrDefault();
        }
    }
}
