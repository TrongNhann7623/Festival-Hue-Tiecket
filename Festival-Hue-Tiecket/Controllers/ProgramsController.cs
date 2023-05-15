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
    public class ProgramsController : ControllerBase
    {
        private readonly MyDbContext _context;
        public ProgramsController(MyDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var program = _context.programs.ToList();
            return Ok(program);
        }
        [HttpGet("{ProgramID}")]
        public IActionResult GetByLocationID(string ProgramID)
        {
            try
            {
                var programs = _context.programs.SingleOrDefault(PG => PG.ProgramID == int.Parse(ProgramID));
                if (programs == null)
                {
                    return NotFound();
                }
                return Ok(programs);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult CreateNew(ProgramsModels model)
        {
            try
            {
                var program = new Programs
                {
                    LocationID = model.LocationID,
                    Name = model.Name,                   
                    Content = model.Content,
                    PathImage = model.PathImage,
                    TypeInoff = model.TypeInoff,
                    Price = model.Price,
                    Time = model.Time,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    TypeProgramID = model.TypeProgramID,
                };
                _context.Add(program);
                _context.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{ProgramID}")]
        public IActionResult UpdateProgrambyID(int ProgramID, ProgramsModels model)
        {
            var program = _context.programs.SingleOrDefault(PG => PG.ProgramID == ProgramID);
            if (program != null)
            {
                program.LocationID = model.LocationID;
                program.Name = model.Name;
                program.Content = model.Content;
                program.PathImage = model.PathImage;
                program.TypeInoff = model.TypeInoff;
                program.Price = model.Price;
                program.Time = model.Time;
                program.StartDate = model.StartDate;
                program.EndDate = model.EndDate;
                program.TypeProgramID = model.TypeProgramID;
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
        [HttpDelete("{ProgramID}")]
        public async Task<IActionResult> DeleteProgramID(int ProgramID)
        {
            var program = await _context.programs.FindAsync(ProgramID);
            if (program != null)
            {
                _context.programs.Remove(program);
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
