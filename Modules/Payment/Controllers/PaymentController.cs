using Microsoft.AspNetCore.Mvc;
using CleaningServiceAPI.Modules.Payment.Services;

namespace CleaningServiceAPI.Modules.Payment.Controllers
{


    [ApiController]
    [Route("api/payment")]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentService _service;

        public PaymentController(PaymentService service)
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