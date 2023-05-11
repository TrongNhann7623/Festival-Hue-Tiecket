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
    public class LocationLikedController : ControllerBase
    {
        public static List<LocationLiked> LocationLikeds = new List<LocationLiked>();
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(LocationLikeds);
        }
        [HttpPost]
        public IActionResult Create(LocationLiked locationLiked)
        {
            var LocationLikedd = new LocationLiked
            {
                LocationLikedID = locationLiked.LocationLikedID,
                LocationID = locationLiked.LocationID,
                UserID = locationLiked.UserID,
            };
            return Ok(new
            {
                Success = true,
                Data = locationLiked
            });

        }
    }
}
