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
    public class NewsController : ControllerBase
    {
        public static List<News> news = new List<News>();
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(news);
        }
        [HttpPost]
        public IActionResult Create(News news)
        {
            var newss = new News
            {
                NewsID = news.NewsID,
                Name = news.Name,
                Summary = news.Summary,
                Content = news.Content,
                PathImage = news.PathImage,
                PostDay = news.PostDay,
                
            };
            return Ok(new
            {
                Success = true,
                Data = news
            });

        }
    }
}
