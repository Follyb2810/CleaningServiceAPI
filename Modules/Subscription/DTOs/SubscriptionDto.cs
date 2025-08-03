namespace CleaningServiceAPI.Modules.Subscription.DTOs
{


    public class SubscriptionDto
    {
        // Define DTO here
    }

    public class CreateSubscriptionDto
    {
        public int UserId { get; set; }
        public int SubscriptionPlanId { get; set; }
        public DateTime StartDate { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentReference { get; set; }
    }
}
