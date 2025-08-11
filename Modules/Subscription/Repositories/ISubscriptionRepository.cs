using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleaningServiceAPI.Modules.Booking.Models;
using CleaningServiceAPI.Modules.Subscription.Models;
using CleaningServiceAPI.Contract;
using CleaningServiceAPI.Modules.Booking.DTOs;


namespace CleaningServiceAPI.Modules.Subscription.Repositories
{
    public interface ISubscriptionRepository : IBaseRepository<SubscriptionModel>
    {
        Task<SubscriptionModel> GetSubscriptionByIdAsync(string id);
        Task<IEnumerable<SubscriptionModel>> GetSubscriptionsByUserAsync(string userId);
        Task<SubscriptionModel> UpdateSubscriptionStatusAsync(string id, SubscriptionStatus status);
        Task<IEnumerable<BookingModel>> GenerateRecurringBookingsAsync(string subscriptionId);
        Task<IEnumerable<SubscriptionPlan>> GetAllSubscriptionPlansAsync();
        Task<SubscriptionPlan> GetSubscriptionPlanByIdAsync(string id);

    }
}
