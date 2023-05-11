using Festival_Hue_Tiecket.Data;
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
        public static List<Tickets> tickets = new List<Tickets>();
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(tickets);
        }
        [HttpPost]
        public IActionResult Create(Tickets tickets)
        {
            var Ticketss = new Tickets
            {
                TicketID = tickets.TicketID,
                Price = tickets.Price,
                Code = tickets.Code,
                Status = tickets.Status,
                UserID = tickets.UserID,
                TicketTypeID = tickets.TicketTypeID,

            };
            return Ok(new
            {
                Success = true,
                Data = tickets
            });

        }
    }
}
