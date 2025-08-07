using CleaningServiceAPI.Data;
using CleaningServiceAPI.Modules.Subscription.Models;
using CleaningServiceAPI.Modules.Booking.Models;
using CleaningServiceAPI.Contract;
using Microsoft.EntityFrameworkCore;
using CleaningServiceAPI.Modules.Subscription.Mappers;
namespace CleaningServiceAPI.Modules.Subscription.Repositories
{
    public class SubscriptionRepository : Repository<SubscriptionModel>, ISubscriptionRepository
    {
        private readonly CleaningServiceDbContext _context;

        public SubscriptionRepository(CleaningServiceDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<SubscriptionModel> GetSubscriptionByIdAsync(int id)
        {
            return await _context.Subscriptions
                .Include(s => s.User)
                .Include(s => s.SubscriptionPlan)
                .Include(s => s.Bookings)
                .FirstOrDefaultAsync(s => s.Id == id);
        }
        public async Task<SubscriptionPlan> GetSubscriptionPlanByIdAsync(int id)
        {
            return await _context.SubscriptionPlans.FindAsync(id);
        }

        public async Task<IEnumerable<SubscriptionModel>> GetSubscriptionsByUserAsync(int userId)
        {
            return await _context.Subscriptions
                .Include(s => s.SubscriptionPlan)
                .Include(s => s.Bookings)
                .Where(s => s.UserId == userId.ToString())
                .ToListAsync();
        }

        public async Task<SubscriptionModel> UpdateSubscriptionStatusAsync(int id, SubscriptionStatus status)
        {
            var subscription = await FindByIdAsync(id);
            if (subscription == null) return null;

            subscription.Status = status;
            subscription.UpdatedAt = DateTimeOffset.UtcNow;

            if (status == SubscriptionStatus.Cancelled || status == SubscriptionStatus.Expired)
            {
                subscription.EndDate = DateTimeOffset.UtcNow;
            }

            await _context.SaveChangesAsync();
            return subscription;
        }

        public async Task<IEnumerable<BookingModel>> GenerateRecurringBookingsAsync(int subscriptionId)
        {
            var subscription = await GetSubscriptionByIdAsync(subscriptionId);
            if (subscription == null || subscription.Status != SubscriptionStatus.Active)
                return null;

            var bookings = new List<BookingModel>();
            var currentDate = subscription.NextCleaningDate;
            var endDate = DateTimeOffset.UtcNow.AddMonths(3);

            while (currentDate <= endDate)
            {
                var booking = subscription.ToCreateSubscriptionBooking(subscriptionId, currentDate ?? DateTimeOffset.UtcNow);
                bookings.Add(booking);
                // currentDate = currentDate.AddDays(7); // Weekly
            }

            _context.Bookings.AddRange(bookings);
            subscription.NextCleaningDate = currentDate;
            subscription.UpdatedAt = DateTimeOffset.UtcNow;

            await _context.SaveChangesAsync();
            return bookings;
        }

        public async Task<IEnumerable<SubscriptionPlan>> GetAllSubscriptionPlansAsync()
        {
            return await _context.SubscriptionPlans
                .Where(x => x.IsActive)
                .OrderBy(x => x.Price)
                .ToListAsync();
        }


    }
}
