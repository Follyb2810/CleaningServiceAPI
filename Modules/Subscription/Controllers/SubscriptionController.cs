using Microsoft.AspNetCore.Mvc;
using CleaningServiceAPI.Modules.Subscription.Services;

namespace CleaningServiceAPI.Modules.Subscription.Controllers
{


    [ApiController]
    [Route("api/subscription")]
    public class SubscriptionController : ControllerBase
    {
        private readonly SubscriptionService _service;

        public SubscriptionController(SubscriptionService service)
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