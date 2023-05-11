using Festival_Hue_Tiecket.Models;
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
    public class HelpsMenuController : ControllerBase
    {
        public static List<HelpsMenu> helpsMenus = new List<HelpsMenu>();
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(helpsMenus);
        }
        [HttpPost]
        public IActionResult Create
    }
}
