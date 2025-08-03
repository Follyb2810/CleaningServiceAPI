using Microsoft.AspNetCore.Mvc;
using CleaningServiceAPI.Modules.User.Models;
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
        public async Task<IActionResult> GetByEmail([FromBody]  string email)
        {
            var user = await _service.GetUserByEmailAsync(email);
            return user == null ? NotFound() : Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserModel user)
        {
            await _service.CreateUserAsync(user);
            return CreatedAtAction(nameof(GetByEmail), new { email = user.Email }, user);
        }
    }
}
