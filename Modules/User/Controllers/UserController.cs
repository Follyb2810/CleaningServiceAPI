using Microsoft.AspNetCore.Mvc;
using CleaningServiceAPI.Modules.User.Services;

namespace CleaningServiceAPI.Modules.User.Controllers
{


    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly UserService _service;

        public UserController(UserService service)
        {
            _service = service;
        }

        // [HttpGet]
        // public IActionResult First()
        // {
        //     var result = _service.First();
        //     return Ok(result);
        // }
        // [HttpGet("{email}")]
        // public async Task<IActionResult> Get(string email)
        // {
        //     var user = await _service.GetUserByEmail(email);
        //     return user == null ? NotFound() : Ok(user);
        // }

        // [HttpPost]
        // public async Task<IActionResult> Create([FromBody] User user)
        // {
        //     await _service.Create(user);
        //     return CreatedAtAction(nameof(Get), new { email = user.Email }, user);
        // }
    }
}