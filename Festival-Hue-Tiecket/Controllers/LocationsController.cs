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
    public class LocationsController : ControllerBase
    {
        public static List<Locations> locations = new List<Locations>();
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(locations);
        }
        [HttpPost]
        public IActionResult Create(Locations locations)
        {
            var location = new Locations
            {
                LocationID = locations.LocationID,
                Name = locations.Name,
                Summary = locations.Summary,
                Content = locations.Content,
                PathImage = locations.PathImage,
                Longtitude = locations.Longtitude,
                Latitude = locations.Latitude,
            };
            return Ok(new
            {
                Success = true,
                Data = locations
            });

        }
    }
}
