using CwkBooking3.API.Services;
using CwkBooking3.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CwkBooking3.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly MyFirstService _myFirstService;
        public HotelsController(MyFirstService myFirstService)
        {
            _myFirstService = myFirstService;
        }

        [HttpGet]
        public IActionResult GetAllHotels()
        {
            var hotels = _myFirstService.GetHotels();
            return Ok(hotels);
        }


        [Route("{id}")]
        [HttpGet]
        public IActionResult GetHotelById(int id)
        {
            var hotels = _myFirstService.GetHotels();
            var hotel = hotels.FirstOrDefault(h => h.Id == id);

            if (hotel == null)
                return NotFound();

            return Ok(hotel);
        }

        [HttpPost]
        public IActionResult CreateHotel([FromBody] Hotel hotel)
        {
            var hotels = _myFirstService.GetHotels();
            hotels.Add(hotel);
            return CreatedAtAction(nameof(GetHotelById), new { id = hotel.Id }, hotel);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateHotel([FromBody] Hotel updated, int id)
        {
            var hotels = _myFirstService.GetHotels();
            var old = hotels.FirstOrDefault(h => h.Id == id);

            if (old == null)
                return NotFound("No resource with the corresponding ID found");

            hotels.Remove(old);
            hotels.Add(updated);
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteHotel(int id)
        {
            var hotels = _myFirstService.GetHotels();
            var toDelete = hotels.FirstOrDefault(h => h.Id == id);

            if (toDelete == null)
                return NotFound("No resource found with the provided ID");

            hotels.Remove(toDelete);
            return NoContent();
        }
    }
}
