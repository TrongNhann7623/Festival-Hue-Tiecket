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
    public class NewsController : ControllerBase
    {
        private readonly MyDbContext _context;
        public NewsController(MyDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var news = _context.News.ToList();
            return Ok(news);
        }
        [HttpGet("{NewsID}")]
        public IActionResult GetByNewsID(string NewsID)
        {
            try
            {
                var news = _context.News.SingleOrDefault(NN => NN.NewsID == int.Parse(NewsID));
                if (news == null)
                {
                    return NotFound();
                }
                return Ok(news);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult CreateNew(NewsModels model)
        {
            try
            {
                var news = new News
                {
                    Name = model.Name,
                    Summary = model.Summary,
                    Content = model.Content,
                    PathImage = model.PathImage,
                    PostDay = model.PostDay,
                   
                };
                _context.Add(news);
                _context.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{NewsID}")]
        public IActionResult UpdateNewsID(int NewsID, NewsModels model)
        {
            var news = _context.News.SingleOrDefault(NN => NN.NewsID == NewsID);
            if (news != null)
            {
                news.Name = model.Name;
                news.Summary = model.Summary;
                news.Content = model.Content;
                news.PathImage = model.PathImage;
                news.PostDay = model.PostDay;
               
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
        [HttpDelete("{NewsID}")]
        public async Task<IActionResult> DeleteLocationID(int NewsID)
        {
            var newss = await _context.News.FindAsync(NewsID);
            if (newss != null)
            {
                _context.News.Remove(newss);
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
