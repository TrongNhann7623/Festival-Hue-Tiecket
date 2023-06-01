using Festival_Hue_Tiecket.Data;
using Festival_Hue_Tiecket.Modelsss;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ZXing;
using ZXing.QrCode;
using ZXing.Windows.Compatibility;

namespace Festival_Hue_Tiecket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketCheckinController : ControllerBase
    {
        private readonly MyDbContext _context;
        public TicketCheckinController(MyDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var role = _context.TicketCheckins.ToList();
            return Ok(role);
        }
        [HttpGet("{TicketCheckinID}")]
        public IActionResult GetByID(int TicketCheckinID)
        {
            try
            {
                var ticketCheckin = _context.TicketCheckins.SingleOrDefault(TKC => TKC.TicketCheckinID == TicketCheckinID);
                if (ticketCheckin == null)
                {
                    return NotFound();
                }
                return Ok(ticketCheckin);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost("createqrcode")]
        public ActionResult<Tickets> GenerateQRCode(Tickets ticket)
        {
            BarcodeWriter writer = new BarcodeWriter();
            QrCodeEncodingOptions options = new QrCodeEncodingOptions
            {
                Width = 300,
                Height = 300,
                DisableECI = true,
                CharacterSet = "UTF-8"
            };
            writer.Format = BarcodeFormat.QR_CODE;
            writer.Options = options;
            var data = new
            {
                TicketName = ticket.TicketID,
                TicketTypeName = _context.TicketTypes.Where(x => x.TicketTypeID == ticket.TicketTypeId).Select(x => x.Name).FirstOrDefault(),
                TicketBook = _context.Tickets.Where(x => x.TicketID == ticket.TicketID).Select(x => x.TicketID).FirstOrDefault(),
                Customer = _context.Users.Where(x => x.UserID == ticket.TicketID).Select(x => x.UserName).FirstOrDefault(),
                Fdate = ticket.CreatedDate
            }.ToString();

            Console.WriteLine(data);
            Bitmap qrCodeBitmap = writer.Write(data);

            MemoryStream ms = new MemoryStream();
            qrCodeBitmap.Save(ms, ImageFormat.Png);
            byte[] qrCodeBytes = ms.ToArray();

            string imagePath = "Img/QRTicket/qrticket" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".png";
            qrCodeBitmap.Save(imagePath, ImageFormat.Png);

            return File(qrCodeBytes, "image/png");
        }
        [HttpPost("qrcode")]
        public IActionResult DecodeQRCode(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            using (var stream = file.OpenReadStream())
            {
                var reader = new BarcodeReader();
                var result = reader.Decode(new BitmapLuminanceSource(new Bitmap(stream)));

                if (result != null)
                {
                    string decodedData = result.Text;
                    return Ok(decodedData);
                }
                else
                {
                    return BadRequest("Unable to decode QR code.");
                }
            }
        }
        [HttpPost]
        public IActionResult CreateNew(TicketCheckinModels model)
        {
            try
            {
                var ticketCheckin = new TicketCheckin
                {                  
                    CreateTime = model.CreateTime,
                    Status = model.Status,
                    TicketID = model.TicketID,
                    UserID = model.UserID,


                };
                _context.Add(ticketCheckin);
                _context.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{TicketCheckinID}")]
        public IActionResult UpdateRolesByID(int TicketCheckinID, TicketCheckin model)
        {
            var ticketCheckin = _context.TicketCheckins.SingleOrDefault(TKC => TKC.TicketCheckinID == TicketCheckinID);
            if (ticketCheckin != null)
            {
                ticketCheckin.CreateTime = model.CreateTime;
                ticketCheckin.Status = model.Status;
                ticketCheckin.TicketID = model.TicketID;
                ticketCheckin.UserID = model.UserID;
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
        [HttpDelete("{TicketCheckinID}")]
        public async Task<IActionResult> DeleteTicketCheckinID(int TicketCheckinID)
        {
            var ticketCheckin = await _context.TicketCheckins.FindAsync(TicketCheckinID);
            if (ticketCheckin != null)
            {
                _context.TicketCheckins.Remove(ticketCheckin);
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
