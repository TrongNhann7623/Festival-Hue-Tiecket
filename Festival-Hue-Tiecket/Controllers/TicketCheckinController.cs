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
    public class TicketCheckinController : ControllerBase
    {
        public static List<TicketCheckin> ticketCheckins = new List<TicketCheckin>();
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(ticketCheckins);
        }
        [HttpPost]
        public IActionResult Create(TicketCheckin ticketCheckin)
        {
            var TicketCheckinn = new TicketCheckin
            {
                TicketCheckinID = ticketCheckin.TicketCheckinID,
                CreateTime = ticketCheckin.CreateTime,
                Status = ticketCheckin.Status,
                TicketID = ticketCheckin.TicketID,
                UserID = ticketCheckin.UserID,
                
            };
            return Ok(new
            {
                Success = true,
                Data = ticketCheckin
            });

        }
    }
}
