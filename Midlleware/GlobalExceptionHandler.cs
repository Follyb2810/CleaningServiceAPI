using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CleaningServiceAPI.Middleware
{
    
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            _logger.LogError(exception, "Exception occurred: {Message}", exception.Message);

            var problem = new ProblemDetails
            {
                Title = "An unexpected error occurred.",
                Detail = exception.Message,
                Status = StatusCodes.Status500InternalServerError
            };

            httpContext.Response.StatusCode = problem.Status ?? StatusCodes.Status500InternalServerError;
            httpContext.Response.ContentType = "application/json";

            var json = JsonSerializer.Serialize(problem);
            await httpContext.Response.WriteAsync(json, cancellationToken);

            return true; // Exception handled
        }
    }
}

// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.Logging;

// namespace CleaningServiceAPI.Midlleware
// {

//     public class GlobalExceptionHandler : IExceptionHandler
//     {
//         private readonly ILogger<GlobalExceptionHandler> _logger;
//         public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
//         {
//             _logger = logger;
//         }
//         public async ValueTask<bool> TryHandleAsync(
//             HttpContext httpContext,
//             Exception exception,
//             CancellationToken cancellationToken)
//         {
//             _logger.LogError(exception, "Exception occurer {Message}", exception.Message);
//             var problem = new ProblemDetails
//             {
//                 Title = exception.Message,
//                 StatusCode = exception.StatusCode500InternalServerError,
//             };
//             httpContext.Response.StatusCode = problem.StatusCode.Value;
//             // httpContext.Response.StatusCode = 500;
//             await httpContext.Response.WriteAsync(problem ??"Something went wrong.",cancellationToken);
//             return true; // Indicates that the exception was handled
//         }
//     }
// }