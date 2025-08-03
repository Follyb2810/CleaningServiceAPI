using CleaningServiceAPI.Modules.Subscription.Repositories;
using CleaningServiceAPI.Modules.Subscription.Services;

namespace CleaningServiceAPI.Modules.Subscription.Modules
{


    public static class SubscriptionModule
    {
        public static IServiceCollection AddSubscriptionModule(this IServiceCollection services)
        {
            services.AddScoped<SubscriptionService>();
            services.AddScoped<SubscriptionRepository>();
            return services;
        }
    }
}