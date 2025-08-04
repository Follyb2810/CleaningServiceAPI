using Microsoft.Extensions.DependencyInjection;
using CleaningServiceAPI.Modules.User.Models;

namespace CleaningServiceAPI.Extensions
{
    public static class CorsExtension
    {
        public static IServiceCollection AddWithCors(this IServiceCollection _services)
        {
            _services.AddCors(options =>
            {
                options.AddPolicy("AllowAngular",
                    policy => policy.WithOrigins("http://localhost:4200")
                                    .AllowAnyMethod()
                                    .AllowAnyHeader()
                                    .AllowCredentials());

                // Uncomment to allow any origin
                // options.AddPolicy("AllowAll", policy =>
                // {
                //     policy.AllowAnyOrigin()
                //           .AllowAnyMethod()
                //           .AllowAnyHeader();
                // });
            });

            return _services;
        }
    }
}
