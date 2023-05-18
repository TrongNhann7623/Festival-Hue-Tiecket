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
    public class TicketsController : ControllerBase
    {
        private readonly MyDbContext _context;
        public TicketsController(MyDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var ticket = _context.tickets.ToList();
            return Ok(ticket);
        }
        [HttpGet("{TicketID}")]
        public IActionResult GetByID(int TicketID)
        {
            try
            {
                var ticket = _context.tickets.SingleOrDefault(TK => TK.TicketID == TicketID);
                if (ticket == null)
                {
                    return NotFound();
                }
                return Ok(ticket);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult CreateNew(TicketModels model)
        {
            try
            {
                var ticket = new Tickets
                {
                    Price = model.Price,
                    Code = model.Code,
                    Status = model.Status,
                    UserID = model.UserID,
                    TicketTypeID = model.TicketTypeID,
                   
                };
                _context.Add(ticket);
                _context.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{TicketID}")]
        public IActionResult UpdateRolesByID(int TicketID, Tickets model)
        {
            var ticket = _context.tickets.SingleOrDefault(TK => TK.TicketID == TicketID);
            if (ticket != null)
            {
                ticket.Price = model.Price;
                ticket.Code = model.Code;
                ticket.Status = model.Status;
                ticket.UserID = model.UserID;
                ticket.TicketTypeID = model.TicketTypeID;
               
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
        [HttpDelete("{TicketID}")]
        public async Task<IActionResult> DeleteTicketID(int TicketID)
        {
            var ticket = await _context.tickets.FindAsync(TicketID);
            if (ticket != null)
            {
                _context.tickets.Remove(ticket);
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
