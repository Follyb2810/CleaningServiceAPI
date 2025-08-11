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

        [HttpGet("first")] // GET api/cleaner/first
        public IActionResult First()
        {
            var result = _service.First();
            return Ok(result);
        }

        [HttpGet("all_cleaner")] // GET api/cleaner/all_cleaner
        public IActionResult GetAllCleaner()
        {
            var result = _service.First();
            return Ok(result);
        }
    }

}