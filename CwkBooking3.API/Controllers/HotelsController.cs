using CwkBooking3.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace CwkBooking3.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly ILogger<HotelsController> _ilogger;
        private readonly HttpContext _context;
        public HotelsController(ILogger<HotelsController> ilogger, IHttpContextAccessor httpContextAccessor)
        {
            _ilogger = ilogger;
            _context = httpContextAccessor.HttpContext;
        }

        [HttpGet]
        public IActionResult GetAllHotels()
        {
            _context.Request.Headers.TryGetValue("my-custom-middleware", out var headerDate1);
            _context.Request.Headers.TryGetValue("second-middleware", out var headerDate2);

            return Ok(headerDate1 + headerDate2);
        }


        [Route("{id}")]
        [HttpGet]
        public IActionResult GetHotelById(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateHotel([FromBody] Hotel hotel)
        {
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateHotel([FromBody] Hotel updated, int id)
        {
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteHotel(int id)
        {
            return NoContent();
        }
    }
}
