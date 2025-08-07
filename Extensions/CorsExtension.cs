using Microsoft.Extensions.DependencyInjection;
using CleaningServiceAPI.Common;
namespace CleaningServiceAPI.Extensions
{
    public static class CorsExtension
    {
        public static IServiceCollection AddWithCors(this IServiceCollection _services, CorsOptions? corsOptions = null)
        {
            var allowedOrigins = corsOptions?.AllowedOrigins ?? new[]
            {
        "http://localhost:4200",
        "http://localhost:5173",
        "http://localhost:3000"
            };

            _services.AddCors(options =>
            {
                options.AddPolicy("AllowAngular", policy =>
                {
                    policy.WithOrigins(allowedOrigins)
                          .AllowAnyMethod()
                          .AllowAnyHeader()
                          .AllowCredentials();
                });
            });

            return _services;
        }

    }
}
