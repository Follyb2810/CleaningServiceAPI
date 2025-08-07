using Microsoft.AspNetCore.Mvc;
using CleaningServiceAPI.Modules.Booking.Services;

namespace CleaningServiceAPI.Modules.Booking.Controllers
{

    [ApiController]

    [Route("api/booking")]
    public class BookingController : ControllerBase
    {
        private readonly BookingService _service;

        public BookingController(BookingService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult First()
        {
            var result = _service.First();
            return Ok(result);
        }
        [HttpGet("/all")]
        public IActionResult GetFirst()
        {
            var result = _service.First();
            var now = DateTime.Now;
            now.AddDays(1);
            // now.
            now.AddDays(1);
            // now.SubtractDays(1);
            now.AddDays(-1);
            now.AddDays(1);


            return Ok(result);
        }
    }
}