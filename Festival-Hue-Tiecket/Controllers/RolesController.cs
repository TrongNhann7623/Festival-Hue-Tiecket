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
    public class RolesController : ControllerBase
    {
        public static List<Roles> roles = new List<Roles>();
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(roles);
        }
        [HttpPost]
        public IActionResult Create(Roles roles)
        {
            var Roless = new Roles
            {
                RolesID = roles.RolesID,
                Name = roles.Name,
            };
            return Ok(new
            {
                Success = true,
                Data = roles
            });

        }
    }
}
