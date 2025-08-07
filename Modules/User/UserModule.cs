using CleaningServiceAPI.Modules.User.Repositories;
using CleaningServiceAPI.Modules.User.Services;

namespace CleaningServiceAPI.User.Modules
{
    public static class UserModule
    {
        public static IServiceCollection AddUserModule(this IServiceCollection services)
        {
            // services.AddScoped<UserService>();
            // services.AddScoped<UserRepository>();
            //            builder.Services.AddScoped<UserRepository>();
            // builder.Services.AddScoped<UserService>();
            // builder.Services.AddScoped<IUserService, UserService>();
            // builder.Services.AddScoped<IUserRepository, UserRepository>();
            // builder.Services.AddScoped<IUserRepository, UserRepository>();
            // builder.Services.AddScoped<UserService>(); // optional: use interface for service if you want
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<UserService>(); 


            return services;
        }
    }
}