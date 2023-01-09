using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CwkBooking3.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        public HotelsController()
        {

        }

        [HttpGet]
        public IActionResult GetRooms()
        {
            return Ok("Hello from hotels controller");
        }
    }
}
