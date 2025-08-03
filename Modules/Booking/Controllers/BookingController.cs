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
    }
}