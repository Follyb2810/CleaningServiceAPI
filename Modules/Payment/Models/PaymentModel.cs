using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using CleaningServiceAPI.Modules.Booking.Models;
using CleaningServiceAPI.Modules.Subscription.Models;
using CleaningServiceAPI.Modules.User.Models;

namespace CleaningServiceAPI.Modules.Payment.Models
{
    public enum PaymentStatus
    {
        Pending,
        Completed,
        Failed,
        Refunded
    }

    public enum PaymentMethod
    {
        CreditCard,
        DebitCard,
        BankTransfer,
        Cash,
        DigitalWallet
    }

    public class PaymentModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public UserModel User { get; set; }

        public int? SubscriptionId { get; set; }
        public SubscriptionModel? Subscription { get; set; }

        public int? BookingId { get; set; }
        public BookingModel? Booking { get; set; }

        // [Column(TypeName = "decimal(10,2)")]
        public decimal Amount { get; set; }

        public PaymentStatus Status { get; set; }
        public PaymentMethod Method { get; set; }

        public string PaymentReference { get; set; }
        public string? TransactionId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ProcessedAt { get; set; }
    }
};