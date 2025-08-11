using Microsoft.AspNetCore.Mvc;
using CleaningServiceAPI.Modules.Admin.Services;

namespace CleaningServiceAPI.Modules.Admin.Controllers;

[ApiController]
[Route("api/admin")]
public class AdminController : ControllerBase
{
    private readonly AdminService _service;

    public AdminController(AdminService service)
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