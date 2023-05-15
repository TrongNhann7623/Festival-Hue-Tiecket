using Festival_Hue_Tiecket.Data ;
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
    public class HelpsMenuController : ControllerBase
    {
        private readonly MyDbContext _context;
        public HelpsMenuController(MyDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var HelpMenu = _context.HelpsMenus.ToList();
            return Ok(HelpMenu);
        }
        [HttpGet ("{ID}")]
        public IActionResult GetByID(string ID)
        {
            try
            {
                var helpmenu = _context.HelpsMenus.SingleOrDefault(HM => HM.ID == int.Parse(ID));
                if (helpmenu == null)
                {
                    return NotFound();
                }
                return Ok(helpmenu);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult CreateNew(HelpsMenuModels model)
        {
            try
            {
                var helpsmenu = new HelpsMenu
                {
                    Title = model.Title,
                    Content = model.Content,
                };
                _context.Add(helpsmenu);
                _context.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }       
        }

        [HttpPut("{ID}")]
        public IActionResult UpdateHelpsmenuByID(int ID, HelpsMenuModels model)
        {
            var helpmenu = _context.HelpsMenus.SingleOrDefault(HM => HM.ID == ID);
            if (helpmenu != null)
            {
                helpmenu.Title = model.Title;
                helpmenu.Content = model.Content;

                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
        [HttpDelete("{ID}")]
        public async Task<IActionResult> DeleteHelpsmenuByID(int ID)
        {
            var helpmenu = await _context.HelpsMenus.FindAsync(ID);
            if (helpmenu != null)
            {
                _context.HelpsMenus.Remove(helpmenu);
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
