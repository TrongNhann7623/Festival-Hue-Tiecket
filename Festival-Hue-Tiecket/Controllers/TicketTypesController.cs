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
    public class TicketTypesController : ControllerBase
    {
        private readonly MyDbContext _context;
        public TicketTypesController(MyDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var ticketType = _context.ticketTypes.ToList();
            return Ok(ticketType);
        }
        [HttpGet("{TicketTypeID}")]
        public IActionResult GetByID(string TicketTypeID)
        {
            try
            {
                var ticketType = _context.ticketTypes.SingleOrDefault(TKT => TKT.TicketTypeID == int.Parse(TicketTypeID));
                if (ticketType == null)
                {
                    return NotFound();
                }
                return Ok(ticketType);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult CreateNew(TicketTypesModels model)
        {
            try
            {
                var ticketType = new TicketTypes
                {
                    Name = model.Name,

                };
                _context.Add(ticketType);
                _context.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{TicketTypeID}")]
        public IActionResult UpdateTicketTypeID(int TicketTypeID, TicketTypesModels model)
        {
            var ticketType = _context.ticketTypes.SingleOrDefault(TKT => TKT.TicketTypeID == TicketTypeID);
            if (ticketType != null)
            {
                ticketType.Name = model.Name;
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
        [HttpDelete("{TicketTypeID}")]
        public async Task<IActionResult> DeleteRolesByID(int TicketTypeID)
        {
            var ticketType = await _context.ticketTypes.FindAsync(TicketTypeID);
            if (ticketType != null)
            {
                _context.ticketTypes.Remove(ticketType);
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
