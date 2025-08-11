using CleaningServiceAPI.Modules.Admin.Repositories;
using CleaningServiceAPI.Modules.Admin.Services;

namespace CleaningServiceAPI.Modules.Admin;

public static class AdminModule
{
    public static IServiceCollection AddAdminModule(this IServiceCollection services)
    {

        services.AddScoped<AdminService>();
        services.AddScoped<AdminRepository>();

        return services;
    }
}