using CleaningServiceAPI.Modules.User.Repositories;
using CleaningServiceAPI.Modules.User.Services;

namespace CleaningServiceAPI.User.Modules
{


    public static class UserModule
    {
        public static IServiceCollection AddUserModule(this IServiceCollection services)
        {
            services.AddScoped<UserService>();
            services.AddScoped<UserRepository>();
            return services;
        }
    }
}