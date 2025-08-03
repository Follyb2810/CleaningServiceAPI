using Microsoft.AspNetCore.Mvc;
using CleaningServiceAPI.Modules.Cleaner.Services;

namespace CleaningServiceAPI.Modules.Cleaner.Controllers
{


    [ApiController]
    [Route("api/cleaner")]
    public class CleanerController : ControllerBase
    {
        private readonly CleanerService _service;

        public CleanerController(CleanerService service)
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