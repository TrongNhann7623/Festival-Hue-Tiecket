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
    public class TicketTypesController : ControllerBase
    {
        private readonly MyDbContext _context;
        public TicketTypesController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TicketTypes>>> GetTicketstype()
        {
            if (_context.Tickets == null)
            {
                return NotFound();
            }
            return await _context.TicketTypes.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TicketTypes>> GetTicketType(int id)
        {
            if (_context.TicketTypes == null)
            {
                return NotFound();
            }
            var ticketType = await _context.TicketTypes.FindAsync(id);

            if (ticketType == null)
            {
                return NotFound();
            }

            return ticketType;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTicketType(int id, TicketTypes ticketType)
        {
            if (id != ticketType.TicketTypeID)
            {
                return BadRequest();
            }

            _context.Entry(ticketType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketTypeExists(id))
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
        public async Task<ActionResult<TicketTypes>> PostTicketType(TicketTypes ticketType)
        {
            if (_context.TicketTypes == null)
            {
                return Problem("Entity set 'DataContext.TicketTypes'  is null.");
            }
            _context.TicketTypes.Add(ticketType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTicketType", new { id = ticketType.TicketTypeID }, ticketType);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicketType(int id)
        {
            if (_context.TicketTypes == null)
            {
                return NotFound();
            }
            var ticketType = await _context.TicketTypes.FindAsync(id);
            if (ticketType == null)
            {
                return NotFound();
            }

            _context.TicketTypes.Remove(ticketType);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool TicketTypeExists(int id)
        {
            throw new NotImplementedException();
        }
    }
}
