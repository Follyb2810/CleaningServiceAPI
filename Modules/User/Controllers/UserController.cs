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
        public async Task<ActionResult<IEnumerable<UserModel>>> GetAllUsers()
        {
            DateTime now = DateTime.Now;
            var users = await _service.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("by-email")]
        public async Task<ActionResult<UserModel>> GetByEmail([FromQuery] string email)
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

        [HttpGet("{id}/email")]
        public ActionResult GetUserEmail(int id, [FromQuery] string email)
        {
            return Ok(new { id, email });
        }

        [HttpGet("{userId}/orders/{orderId}/home")]
        public ActionResult GetUserOrderHome(int userId, int orderId)
        {
            // Your logic here
            return Ok(new { userId, orderId });
        }

        [HttpGet("{userId}/orders/{orderId}")]
        public ActionResult GetUserOrderWithStatus(
            [FromRoute] int userId,
            [FromRoute] int orderId,
            [FromQuery] string? status)
        {
            return Ok(new { userId, orderId, status });
        }
    }
}
