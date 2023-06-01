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
    public class TypeProgramController : ControllerBase
    {
        private readonly MyDbContext _context;
        public TypeProgramController(MyDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var typeprogram = _context.TypePrograms.ToList();
            return Ok(typeprogram);
        }
        [HttpGet("{TypeProgramID}")]
        public IActionResult GetByID(string TypeProgramID)
        {
            try
            {
                var typeprogram = _context.TypePrograms.SingleOrDefault(TP => TP.TypeProgramID == int.Parse(TypeProgramID));
                if (typeprogram == null)
                {
                    return NotFound();
                }
                return Ok(typeprogram);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult CreateNew(TypesProgramModels model)
        {
            try
            {
                var typeprogram = new TypeProgram
                {
                    Name = model.Name,

                };
                _context.Add(typeprogram);
                _context.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{TypeProgramID}")]
        public IActionResult UpdateTicketTypeID(int TypeProgramID, TypesProgramModels model)
        {
            var typeprogram = _context.TypePrograms.SingleOrDefault(TP => TP.TypeProgramID == TypeProgramID);
            if (typeprogram != null)
            {
                typeprogram.Name = model.Name;
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
        [HttpDelete("{TypeProgramID}")]
        public async Task<IActionResult> DeleteRolesByID(int TypeProgramID)
        {
            var typeprogram = await _context.TypePrograms.FindAsync(TypeProgramID);
            if (typeprogram != null)
            {
                _context.TypePrograms.Remove(typeprogram);
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
