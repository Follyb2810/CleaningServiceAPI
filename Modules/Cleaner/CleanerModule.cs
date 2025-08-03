using CleaningServiceAPI.Modules.Cleaner.Repositories;
using CleaningServiceAPI.Modules.Cleaner.Services;

namespace CleaningServiceAPI.Modules.Cleaner.Modules
{
    public static class CleanerModule
    {
        public static IServiceCollection AddCleanerModule(this IServiceCollection services)
        {
            services.AddScoped<CleanerService>();
            services.AddScoped<CleanerRepository>();
            return services;
        }
    }
}