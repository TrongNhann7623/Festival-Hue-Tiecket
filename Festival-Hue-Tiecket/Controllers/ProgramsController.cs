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
    public class ProgramsController : ControllerBase
    {
        public static List<Programs> programs = new List<Programs>();
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(programs);
        }
        [HttpPost]
        public IActionResult Create(Programs program)
        {
            var Programss = new Programs
            {
                ProgramID = program.ProgramID,
                LocationID = program.LocationID,
                Name = program.Name,
                Content = program.Content,
                PathImage = program.PathImage,
                TypeInoff = program.TypeInoff,
                Price = program.Price,
                Time = program.Time,
                StartDate = program.StartDate,
                EndDate = program.EndDate,
                TypeProgramID = program.TypeProgramID,
            };
            return Ok(new
            {
                Success = true,
                Data = program
            });

        }
    }
}
