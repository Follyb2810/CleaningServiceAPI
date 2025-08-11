namespace CleaningServiceAPI.Modules.Subscription.DTOs
{


    public class SubscriptionDto
    {
        // Define DTO here
    }

    public class CreateSubscriptionDto
    {
        public string UserId { get; set; }
        public string SubscriptionPlanId { get; set; }
        public DateTime StartDate { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentReference { get; set; }
        public int DurationHours { get; set; }
    }
}
