using CwkBooking3.DAL;
using CwkBooking3.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CwkBooking3.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly ILogger<HotelsController> _ilogger;
        private readonly HttpContext _context;
        private readonly CwkBooking3Context _dbContext;
        public HotelsController(ILogger<HotelsController> ilogger, IHttpContextAccessor httpContextAccessor, CwkBooking3Context dbContext)
        {
            _ilogger = ilogger;
            _context = httpContextAccessor.HttpContext;
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHotels()
        {
            //_context.Request.Headers.TryGetValue("my-custom-middleware", out var headerDate1);
            //_context.Request.Headers.TryGetValue("second-middleware", out var headerDate2);

            //return Ok(headerDate1 + headerDate2);
            var hotels = await _dbContext.Hotels.ToListAsync();
            return Ok(hotels);
        }


        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetHotelById(int id)
        {
            var hotel = await _dbContext.Hotels.FirstOrDefaultAsync(h => h.Id == id);
            return Ok(hotel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateHotel([FromBody] Hotel hotel)
        {
            _dbContext.Hotels.Add(hotel);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetHotelById), new { id = hotel.Id }, hotel);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateHotel([FromBody] Hotel updated, int id)
        {
            var hotel = await _dbContext.Hotels.FirstOrDefaultAsync(h => h.Id == id);

            if (hotel == null)
                return BadRequest();

            hotel.Id = updated.Id;
            hotel.Address = updated.Address;
            hotel.Description = updated.Description;
            hotel.Country = updated.Country;
            hotel.City = updated.City;

            _dbContext.Hotels.Update(hotel);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            var hotel = await _dbContext.Hotels.FirstOrDefaultAsync(h => h.Id == id);
            _dbContext.Hotels.Remove(hotel);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
