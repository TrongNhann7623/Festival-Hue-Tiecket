using Festival_Hue_Tiecket.Data;
using Festival_Hue_Tiecket.Modelsss;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Festival_Hue_Tiecket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly MyDbContext _context;
        public LocationsController(MyDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Locations>>> GetLocations()
        {
            if (_context.Locationss == null)
            {
                return NotFound();
            }
            return await _context.Locationss.ToListAsync();
        }
        [HttpGet("{LocationID}")]
        public async Task<ActionResult<Locations>> GetLocation(int LocationID)
        {
            if (_context.Locationss == null)
            {
                return NotFound();
            }
            var location = await _context.Locationss.FindAsync(LocationID);

            if (location == null)
            {
                return NotFound();
            }

            return location;
        }
        [HttpPut("{LocationID}")]
        public async Task<IActionResult> PutLocation(int id, Locations location)
        {
            if (id != location.LocationID)
            {
                return BadRequest();
            }

            _context.Entry(location).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocationExists(id))
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
        [HttpPost]
        public async Task<ActionResult<Locations>> PostLocation(Locations location)
        {
            if (_context.Locationss == null)
            {
                return Problem("Entity set 'DataContext.Locations'  is null.");
            }
            _context.Locationss.Add(location);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLocation", new { id = location.LocationID }, location);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            if (_context.Locationss == null)
            {
                return NotFound();
            }
            var location = await _context.Locationss.FindAsync(id);
            if (location == null)
            {
                return NotFound();
            }

            _context.Locationss.Remove(location);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool LocationExists(int id)
        {
            throw new NotImplementedException();
        }     
    }
}
