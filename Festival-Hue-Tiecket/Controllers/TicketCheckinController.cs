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
    public class TicketCheckinController : ControllerBase
    {
        private readonly MyDbContext _context;
        public TicketCheckinController(MyDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var role = _context.ticketCheckins.ToList();
            return Ok(role);
        }
        [HttpGet("{TicketCheckinID}")]
        public IActionResult GetByID(int TicketCheckinID)
        {
            try
            {
                var ticketCheckin = _context.ticketCheckins.SingleOrDefault(TKC => TKC.TicketCheckinID == TicketCheckinID);
                if (ticketCheckin == null)
                {
                    return NotFound();
                }
                return Ok(ticketCheckin);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult CreateNew(TicketCheckinModels model)
        {
            try
            {
                var ticketCheckin = new TicketCheckin
                {                  
                    CreateTime = model.CreateTime,
                    Status = model.Status,
                    TicketID = model.TicketID,
                    UserID = model.UserID,


                };
                _context.Add(ticketCheckin);
                _context.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{TicketCheckinID}")]
        public IActionResult UpdateRolesByID(int TicketCheckinID, TicketCheckin model)
        {
            var ticketCheckin = _context.ticketCheckins.SingleOrDefault(TKC => TKC.TicketCheckinID == TicketCheckinID);
            if (ticketCheckin != null)
            {
                ticketCheckin.CreateTime = model.CreateTime;
                ticketCheckin.Status = model.Status;
                ticketCheckin.TicketID = model.TicketID;
                ticketCheckin.UserID = model.UserID;
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
        [HttpDelete("{TicketCheckinID}")]
        public async Task<IActionResult> DeleteTicketCheckinID(int TicketCheckinID)
        {
            var ticketCheckin = await _context.ticketCheckins.FindAsync(TicketCheckinID);
            if (ticketCheckin != null)
            {
                _context.ticketCheckins.Remove(ticketCheckin);
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
