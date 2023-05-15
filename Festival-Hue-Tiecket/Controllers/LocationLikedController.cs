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
    public class LocationLikedController : ControllerBase
    {
        private readonly MyDbContext _context;
        public LocationLikedController(MyDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var locationLike = _context.LocationLikeds.ToList();
            return Ok(locationLike);
        }
        [HttpGet("{ID}")]
        public IActionResult GetByID(string ID)
        {
            try
            {
                var locationLike = _context.LocationLikeds.SingleOrDefault(LoL => LoL.LocationLikedID == int.Parse(ID));
                if (locationLike == null)
                {
                    return NotFound();
                }
                return Ok(locationLike);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult CreateNew(LocationLikeModels model)
        {
            try
            {
                var locationLike = new LocationLiked
                {
                    LocationID = model.LocationID,
                    UserID = model.UserID,
                };
                _context.Add(locationLike);
                _context.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{ID}")]
        public IActionResult UpdateLocationLikeByID(int ID, LocationLikeModels model)
        {
            var locationLike = _context.LocationLikeds.SingleOrDefault(HM => HM.LocationLikedID == ID);
            if (locationLike != null)
            {
                locationLike.LocationID = model.LocationID;
                locationLike.UserID = model.UserID;
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
        [HttpDelete("{ID}")]
        public async Task<IActionResult> DeleteLocationLikeByID(int ID)
        {
            var locationLike = await _context.LocationLikeds.FindAsync(ID);
            if (locationLike != null)
            {
                _context.LocationLikeds.Remove(locationLike);
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
