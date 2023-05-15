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
    public class ProgramLikedController : ControllerBase
    {
        private readonly MyDbContext _context;
        public ProgramLikedController(MyDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var programLikedss = _context.programLikeds.ToList();
            return Ok(programLikedss);
        }
        [HttpGet("{ProgramLikeID}")]
        public IActionResult GetByID(int ProgramLikeID)
        {
            try
            {
                var programliked = _context.programLikeds.SingleOrDefault(PGL => PGL.ProgramLikeID ==ProgramLikeID);
                if (programliked == null)
                {
                    return NotFound();
                }
                return Ok(programliked);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult CreateNew(ProgramLikedModels model)
        {
            try
            {
                var programliked = new ProgramLiked
                {
                    ProgramID = model.ProgramID,
                    UserID = model.UserID,
                };
                _context.Add(programliked);
                _context.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{ProgramLikeID}")]
        public IActionResult UpdateLocationLikeByID(int ProgramLikeID, ProgramLikedModels model)
        {
            var programLiked = _context.programLikeds.SingleOrDefault(PGL => PGL.ProgramLikeID == ProgramLikeID);
            if (programLiked != null)
            {
                programLiked.ProgramID = model.ProgramID;
                programLiked.UserID = model.UserID;
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
        [HttpDelete("{ProgramLikeID}")]
        public async Task<IActionResult> DeleteProgramLikedByID(int ProgramLikeID)
        {
            var programliked = await _context.programLikeds.FindAsync(ProgramLikeID);
            if (programliked != null)
            {
                _context.programLikeds.Remove(programliked);
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
