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
    public class TicketsController : ControllerBase
    {
        
        private readonly MyDbContext _context;
        public TicketsController(MyDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tickets>>> GetTickets()
        {
            if (_context.Tickets == null)
            {
                return NotFound();
            }
            return await _context.Tickets.ToListAsync();
        }
        [HttpGet("{id}")]
        public ActionResult<Tickets> GetTicket(int id)
        {
            try
            {
                var ticket = _context.Tickets.Include(x => x.TicketTypess).FirstOrDefault(x => x.TicketID == id);
                if (ticket == null)
                {
                    return NotFound();
                }
                var tickets = _context.Tickets.AsNoTracking()
                    .Where(x => x.TicketTypeId == ticket.TicketTypeId && x.TicketID != id)
                    .OrderByDescending(x => x.CreatedDate)
                    .Take(5)
                    .ToList();
                return ticket;
            }
            catch
            {
                return NotFound();
            }
        }
        [HttpGet("get_qrcode_ticket")]
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTicket(int id, Tickets tickets)
        {
            if (id != tickets.TicketID)
            {
                return BadRequest();
            }

            _context.Entry(tickets).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketExists(id))
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
        public async Task<ActionResult<Tickets>> PostTicket(Tickets tickets)
        {
            if (_context.Tickets == null)
            {
                return Problem("Entity set 'DataContext.Tickets'  is null.");
            }
            _context.Tickets.Add(tickets);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTicket", new { id = tickets.TicketID }, tickets);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            if (_context.Tickets == null)
            {
                return NotFound();
            }
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }

            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool TicketExists(int id)
        {
            throw new NotImplementedException();
        }
    }
}
