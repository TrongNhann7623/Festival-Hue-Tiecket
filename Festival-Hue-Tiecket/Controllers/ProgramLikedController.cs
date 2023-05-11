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
    public class ProgramLikedController : ControllerBase
    {
        public static List<ProgramLiked> programLikes = new List<ProgramLiked>();
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(programLikes);
        }
        [HttpPost]
        public IActionResult Create(ProgramLiked programLiked)
        {
            var programlikedd = new ProgramLiked
            {
                ProgramLikeID = programLiked.ProgramLikeID,
                UserID = programLiked.UserID,
                ProgramID = programLiked.ProgramID,
            };
            return Ok(new
            {
                Success = true,
                Data = programLiked
            });

        }
    }
}
