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
    public class NewsLikedController : ControllerBase
    {
        public static List<NewsLiked> newsLikeds = new List<NewsLiked>();
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(newsLikeds);
        }
        [HttpPost]
        public IActionResult Create(NewsLiked newsLiked)
        {
            var NewsLikedd = new NewsLiked
            {
                NewsLikedID = newsLiked.NewsLikedID,
                UserID = newsLiked.UserID,
                NewsID = newsLiked.NewsID,
            };
            return Ok(new
            {
                Success = true,
                Data = newsLiked
            });

        }
    }
}
