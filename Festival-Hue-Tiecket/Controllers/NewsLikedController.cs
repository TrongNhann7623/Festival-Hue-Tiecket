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
    public class NewsLikedController : ControllerBase
    {
        private readonly MyDbContext _context;
        public NewsLikedController(MyDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var newslike = _context.NewsLikeds.ToList();
            return Ok(newslike);
        }
        [HttpGet("{NewsLikedID}")]
        public IActionResult GetByID(string NewsLikedID)
        {
            try
            {
                var newslike = _context.NewsLikeds.SingleOrDefault(NL => NL.NewsLikedID == int.Parse(NewsLikedID));
                if (newslike == null)
                {
                    return NotFound();
                }
                return Ok(newslike);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult CreateNew(NewsLikeModels model)
        {
            try
            {
                var newslike = new NewsLiked
                {
                    NewsID = model.NewsID,
                    UserID = model.UserID,
                };
                _context.Add(newslike);
                _context.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{NewsLikedID}")]
        public IActionResult UpdateLocationLikeByID(int NewsLikedID, NewsLikeModels model)
        {
            var newsLiked  = _context.NewsLikeds.SingleOrDefault(NL => NL.NewsLikedID == NewsLikedID);
            if (newsLiked != null)
            {
                newsLiked.NewsID = model.NewsID;
                newsLiked.UserID = model.UserID;
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
        [HttpDelete("{NewsLikedID}")]
        public async Task<IActionResult> DeleteHelpsmenuByID(int NewsLikedID)
        {
            var newsLiked = await _context.NewsLikeds.FindAsync(NewsLikedID);
            if (newsLiked != null)
            {
                _context.NewsLikeds.Remove(newsLiked);
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
