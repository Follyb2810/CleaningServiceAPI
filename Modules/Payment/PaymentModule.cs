using CleaningServiceAPI.Modules.Payment.Repositories;
using CleaningServiceAPI.Modules.Payment.Services;

namespace CleaningServiceAPI.Modules.Payment.Modules
{


    public static class PaymentModule
    {
        public static IServiceCollection AddPaymentModule(this IServiceCollection services)
        {
            services.AddScoped<PaymentService>();
            services.AddScoped<PaymentRepository>();
            return services;
        }
    }
}