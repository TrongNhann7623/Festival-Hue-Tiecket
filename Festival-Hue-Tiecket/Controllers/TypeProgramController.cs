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
    public class TypeProgramController : ControllerBase
    {
        public static List<TypeProgram> typePrograms = new List<TypeProgram>();
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(typePrograms);
        }
        [HttpPost]
        public IActionResult Create(TypeProgram typeProgram)
        {
            var TypeProgramm = new TypeProgram
            {
                TypeProgramID = typeProgram.TypeProgramID,
                Name = typeProgram.Name,
            };
            return Ok(new
            {
                Success = true,
                Data = typeProgram
            });

        }
    }
}
