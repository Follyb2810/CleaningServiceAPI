using CleaningServiceAPI.Modules.Booking.Repositories;
using CleaningServiceAPI.Modules.Booking.Services;

namespace CleaningServiceAPI.Modules
{
    public static class BookingModule
    {
        public static IServiceCollection AddBookingModule(this IServiceCollection services)
        {
            services.AddScoped<BookingService>();
            services.AddScoped<BookingRepository>();
            return services;
        }
    }
}