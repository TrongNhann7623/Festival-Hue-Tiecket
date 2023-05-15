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
    public class LocationsController : ControllerBase
    {
        private readonly MyDbContext _context;
        public LocationsController(MyDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var locations = _context.locationss.ToList();
            return Ok(locations);
        }
        [HttpGet("{LocationID}")]
        public IActionResult GetByLocationID(string LocationID)
        {
            try
            {
                var locations = _context.locationss.SingleOrDefault(LC => LC.LocationID == int.Parse(LocationID));
                if (locations == null)
                {
                    return NotFound();
                }
                return Ok(locations);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult CreateNew(LocationsModels model)
        {
            try
            {
                var locations = new Locations
                {
                    Name = model.Name,
                    Summary = model.Summary,
                    Content = model.Content,
                    PathImage = model.PathImage,
                    Longtitude = model.Longtitude,
                    Latitude = model.Latitude,
                    LocationLikedID = model.LocationLikedID,
                };
                _context.Add(locations);
                _context.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{LocationID}")]
        public IActionResult UpdateLocationByID(int LocationID, LocationsModels model)
        {
            var locations = _context.locationss.SingleOrDefault(LC => LC.LocationID == LocationID);
            if (locations != null)
            {
                locations.Name = model.Name;
                locations.Summary = model.Summary;
                locations.Content = model.Content;
                locations.PathImage = model.PathImage;
                locations.Longtitude = model.Longtitude;
                locations.Latitude = model.Latitude;
                locations.LocationLikedID = model.LocationLikedID;
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
        [HttpDelete("{LocationID}")]
        public async Task<IActionResult> DeleteLocationID(int LocationID)
        {
            var locations = await _context.locationss.FindAsync(LocationID);
            if (locations != null)
            {
                _context.locationss.Remove(locations);
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
