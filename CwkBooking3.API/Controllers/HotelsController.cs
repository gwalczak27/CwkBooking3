using AutoMapper;
using CwkBooking3.API.DTOs;
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
        private readonly IMapper _mapper;
        public HotelsController(ILogger<HotelsController> ilogger, IHttpContextAccessor httpContextAccessor, CwkBooking3Context dbContext, IMapper mapper)
        {
            _ilogger = ilogger;
            _context = httpContextAccessor.HttpContext;
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHotels()
        {
            //_context.Request.Headers.TryGetValue("my-custom-middleware", out var headerDate1);
            //_context.Request.Headers.TryGetValue("second-middleware", out var headerDate2);

            //return Ok(headerDate1 + headerDate2);
            var hotels = await _dbContext.Hotels.ToListAsync();
            var hotelsGet = _mapper.Map<List<GetHotelDTO>>(hotels);
            return Ok(hotelsGet);
        }


        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetHotelById(int id)
        {
            var hotel = await _dbContext.Hotels.FirstOrDefaultAsync(h => h.Id == id);
            var hotelGet = _mapper.Map<GetHotelDTO>(hotel);
            return Ok(hotelGet);
        }

        [HttpPost]
        public async Task<IActionResult> CreateHotel([FromBody] CreateHotelDTO hotel)
        {
            var domainHotel = _mapper.Map<Hotel>(hotel);
            
            _dbContext.Hotels.Add(domainHotel);
            await _dbContext.SaveChangesAsync();

            var hotelGet = _mapper.Map<GetHotelDTO>(domainHotel);
            return CreatedAtAction(nameof(GetHotelById), new { id = domainHotel.Id }, hotelGet);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateHotel([FromBody] CreateHotelDTO updated, int id)
        {
            var toUpdate = _mapper.Map<Hotel>(updated);
            toUpdate.Id = id;

            _dbContext.Hotels.Update(toUpdate);
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
