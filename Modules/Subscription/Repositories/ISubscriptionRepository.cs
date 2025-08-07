using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleaningServiceAPI.Modules.Booking.Models;
using CleaningServiceAPI.Modules.Subscription.Models;
using CleaningServiceAPI.Contract;
using CleaningServiceAPI.Modules.Booking.DTOs;



// namespace CleaningServiceAPI.Modules.Subscription.Repositories
// {
//     public interface ISubscriptionRepository : IBaseRepository<SubscriptionModel>
//     {
//         Task<SubscriptionModel> GetSubscriptionByIdAsync(int id);

// Task<SubscriptionPlan> GetSubscriptionPlanByIdAsync(int id);

//         Task<IEnumerable<SubscriptionModel>> GetSubscriptionsByUserAsync(int userId);
//         Task<SubscriptionModel> UpdateSubscriptionStatusAsync(int id, SubscriptionStatus status);
//         Task<IEnumerable<BookingModel>> GenerateRecurringBookingsAsync(int subscriptionId);
//         Task<IEnumerable<SubscriptionPlan>> GetAllSubscriptionPlansAsync();
//     }
// }

namespace CleaningServiceAPI.Modules.Subscription.Repositories
{
    public interface ISubscriptionRepository : IBaseRepository<SubscriptionModel>
    {
        Task<SubscriptionModel> GetSubscriptionByIdAsync(int id);
        Task<IEnumerable<SubscriptionModel>> GetSubscriptionsByUserAsync(int userId);
        Task<SubscriptionModel> UpdateSubscriptionStatusAsync(int id, SubscriptionStatus status);
        Task<IEnumerable<BookingModel>> GenerateRecurringBookingsAsync(int subscriptionId);
        Task<IEnumerable<SubscriptionPlan>> GetAllSubscriptionPlansAsync();
        Task<SubscriptionPlan> GetSubscriptionPlanByIdAsync(int id);
        
    }
}
