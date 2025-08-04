using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;


namespace CleaningServiceAPI.Modules.User.Middleware
{
    public class UserMiddleware : IMiddleware
    {
        private readonly ILogger<UserMiddleware> _logger;

        public UserMiddleware(ILogger<UserMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _logger.LogInformation("Before");
            await next(context);
            _logger.LogInformation("After");
        }
    }
}

// builder.Services.AddTransient<UserMiddleware>();
// app.UseMiddleware<UserMiddleware>();
