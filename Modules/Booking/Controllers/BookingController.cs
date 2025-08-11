using Microsoft.AspNetCore.Mvc;
using CleaningServiceAPI.Modules.Booking.Services;
using CleaningServiceAPI.Modules.Booking.DTOs;
using CleaningServiceAPI.Modules.Booking.Models;
using CleaningServiceAPI.Modules.Cleaner.Models;
using CleaningServiceAPI.Modules.Booking.Mappers;


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
        [HttpGet("first")]
        public async Task<object> FirstAll()
        {
            var result = await _service.First();
            return Ok(result);
        }

        [HttpGet("all")]
        public IActionResult GetFirst()
        {
            var result = _service.First();
            var now = DateTime.Now;
            // now.AddDays(1);
            // // now.
            // now.AddDays(1);
            // // now.SubtractDays(1);
            // now.AddDays(-1);
            // now.AddDays(1);
            now = now.AddDays(1);
            now = now.AddDays(-1);
            now = now.AddDays(1);




            return Ok(result);
        }
        [HttpPost("create_booking")]
        public async Task<IActionResult> CreateBooking([FromBody] CreateBookingDto dto)
        {
            var newBooking = await _service.CreateBookingAsync(dto);
            return Ok(new { Message = "Create Booking", newBooking });
        }
        [HttpGet("get_upcoming_booking")]
        // [Route("get_upcoming_booking")]
        public async Task<ActionResult<IEnumerable<BookingModel>>> GetUpcomingBookingsForUser(string userId)
        {
            var booking = await _service.GetUpcomingBookingsForUser(userId);
            if (booking == null || !booking.Any())
                return NotFound(new { Message = "No upcoming bookings found" });

            return Ok(new { Message = "All Booking", booking });
        }

        [HttpGet("get_user_booking/{userId}")]
        public async Task<ActionResult<IEnumerable<BookingModel>>> GetBookingsByUserAsync([FromQuery] string userId)
        {
            var userBooking = await _service.GetBookingsByUserAsync(userId);
            if (userBooking == null) return null;
            return Ok(new { Message = "User Booking", userBooking });
        }
        [HttpGet("get_booking_by_date/{iserId}")]
        public async Task<ActionResult<IEnumerable<BookingModel>>> GetBookingsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            var booking = await _service.GetBookingsByDateRangeAsync(startDate, endDate);
            if (booking == null) return null;
            return Ok(new { Message = "Booking By Date", booking });
        }
        [HttpPost("assign_cleaner")]
        public async Task<ActionResult<BookingModel>> AssignCleanerAsync(string bookingId, string cleanerId)
        {
            var newCleaner = await _service.AssignCleanerAsync(bookingId, cleanerId);
            if (newCleaner == null) return null;
            return Ok(new { Message = "Cleaner Assign", newCleaner });
        }
        [HttpGet("get_booking_byid/{id}")]
        public async Task<ActionResult<BookingModel>> GetBookingByIdAsync(string bookingId)
        {
            var booking = await _service.GetBookingByIdAsync(bookingId);
            if (booking == null) return null;
            return Ok(new { Message = "Booking", booking });
        }

        [HttpPost("complete_booking")]
        public async Task<ActionResult<BookingModel>> CompleteBookingAsync(BookingCompletionDto dto)
        {
            var completeBooking = await _service.CompleteBookingAsync(dto);
            if (completeBooking == null) return null;
            return Ok(new { Message = "Booking Completed", completeBooking });
        }
        [HttpPost("cancel_booking")]
        public async Task<ActionResult<BookingModel>> CancelBookingAsync(string bookingId)
        {
            var cancelBooking = await _service.CancelBookingAsync(bookingId);
            if (cancelBooking == null) return null;
            return Ok(new { Message = "Booking Cancel", cancelBooking });
        }
        [HttpGet("get_available_cleaner")]
        public async Task<ActionResult<IEnumerable<CleanerModel>>> GetAvailableCleanersAsync(DateTime date, TimeSpan time, int durationHours)
        {
            var availableCleaners = await _service.GetAvailableCleanersAsync(date, time, durationHours);
            if (availableCleaners == null) return null;
            return Ok(new { Message = "Avaible Cleaner", availableCleaners });
        }
        [HttpPost("intellisence")]
        public Task GetIntellisense()
        {
            var now = DateTime.Now.AddDays(1);
            return Task.CompletedTask;
        }




    }
}