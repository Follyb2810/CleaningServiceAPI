using CleaningServiceAPI.Modules.Booking.Models;
using CleaningServiceAPI.Modules.Subscription.Models;
using CleaningServiceAPI.Modules.Booking.DTOs;
using CleaningServiceAPI.Modules.Subscription.DTOs;


namespace CleaningServiceAPI.Modules.Subscription.Mappers
{
    public static class SubscriptionMapper
    {
        public static object ToDto(object entity)
        {
            return new
            {
                // TODO: Map fields appropriately
            };
        }
        public static SubscriptionModel CreateSubscription(this SubscriptionModel model, SubscriptionPlan plan)
        {
            return new SubscriptionModel
            {
                UserId = model.UserId,
                SubscriptionPlanId = model.SubscriptionPlanId,
                StartDate = model.StartDate,
                NextCleaningDate = model.StartDate,
                AmountPaid = plan.Price,
                PaymentMethod = model.PaymentMethod,
                PaymentReference = model.PaymentReference,
                Status = SubscriptionStatus.Active
            };
        }
        public static BookingModel ToCreateSubscriptionBooking(this SubscriptionModel subscription, int subscriptionId, DateTimeOffset currentDate)
        {
            return new BookingModel
            {
                UserId = subscription.UserId,
                SubscriptionId = subscriptionId,
                ScheduledDate = currentDate,
                ScheduledTime = new TimeSpan(9, 0, 0),
                DurationHours = subscription.SubscriptionPlan.DurationHours,
                ServiceAddress = subscription.User.Address,
                Type = BookingType.Subscription,
                Price = subscription.SubscriptionPlan.Price,
                Status = BookingStatus.Scheduled
            };
        }
    }
}
