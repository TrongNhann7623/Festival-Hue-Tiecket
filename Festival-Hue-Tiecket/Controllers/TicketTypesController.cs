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
    public class TicketTypesController : ControllerBase
    {
        public static List<TicketTypes> ticketTypes = new List<TicketTypes>();
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(ticketTypes);
        }
        [HttpPost]
        public IActionResult Create(TicketTypes ticketTypes)
        {
            var TicketTypess = new TicketTypes
            {
                TicketTypeID = ticketTypes.TicketTypeID,
                Name = ticketTypes.Name,
            };
            return Ok(new
            {
                Success = true,
                Data = ticketTypes
            });

        }
    }
}
