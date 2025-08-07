using Microsoft.AspNetCore.Mvc;
using CleaningServiceAPI.Modules.User.Models;
using CleaningServiceAPI.Modules.User.DTOs;
using CleaningServiceAPI.Modules.User.Services;

namespace CleaningServiceAPI.Modules.User.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly UserService _service;

        public UserController(UserService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _service.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> GetByEmail([FromBody] string email)
        {
            var user = await _service.GetUserByEmailAsync(email);
            return user == null ? NotFound() : Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto user)
        {
            await _service.CreateUserAsync(user);
            return CreatedAtAction(nameof(GetByEmail), new { email = user.Email }, user);
        }
        [HttpGet("{id}")] // GET /123?email=test@example.com
        public ActionResult EditUser([FromQuery] string email, int id)
        {
            return Ok(new { id, email });
        }
        [HttpGet("user/{userId}/order/{orderId}/home")] // user/123/order/123,
        public ActionResult GetUserOrderv(int userId, int orderId)
        {
            // Your logic here
            return Ok(new { userId, orderId });
        }
        [HttpGet("user/{userId}/order/{orderId}/order")] // GET /user/123/order/456
        public ActionResult GetUserOrder([FromRoute] int userId, [FromRoute] int orderId)
        {
            return Ok(new { userId, orderId });
        }

        [HttpGet("user/{userId}/order/{orderId}")] // /user/123/order/456?status=paid
        public ActionResult GetUserOrder(
            [FromRoute] int userId,
            [FromRoute] int orderId,
            [FromQuery] string status)
        {
            
            return Ok(new { userId, orderId, status });
        }

    }
}
