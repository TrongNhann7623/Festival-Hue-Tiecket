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
    public class UsersController : ControllerBase
    {
        public static List<Users> users = new List<Users>();
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(users);
        }
        [HttpPost]
        public IActionResult Create(Users users)
        {
            var Userss = new Users
            {
                UserID = users.UserID,
                UserName = users.UserName,
                Password = users.Password,
                Email = users.Email,
                SDT = users.SDT,
                RoleID = users.RoleID,

            };
            return Ok(new
            {
                Success = true,
                Data = users
            });

        }
    }
}
