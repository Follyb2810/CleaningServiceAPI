using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using CleaningServiceAPI.Modules.User.Models;
using CleaningServiceAPI.Modules.Cleaner.Models;
using CleaningServiceAPI.Modules.Booking.Models;

namespace CleaningServiceAPI.Modules.Subscription.Models
{
    public enum SubscriptionStatus
    {
        Active,
        Paused,
        Cancelled,
        Expired
    }
    public class SubscriptionPlan
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        // [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        public int CleaningFrequencyDays { get; set; } // 7 for weekly, 30 for monthly, etc.
        public int DurationHours { get; set; }
        public bool IsActive { get; set; } = true;

        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
        // public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public ICollection<SubscriptionModel> Subscriptions { get; set; } = new List<SubscriptionModel>();
    }

    // User subscriptions
    public class SubscriptionModel
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        public UserModel User { get; set; }

        public int SubscriptionPlanId { get; set; }
        public SubscriptionPlan? SubscriptionPlan { get; set; }

        public SubscriptionStatus Status { get; set; } = SubscriptionStatus.Active;
        // public DateTime StartDate { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public DateTimeOffset? NextCleaningDate { get; set; }

        // [Column(TypeName = "decimal(10,2)")]
        public decimal AmountPaid { get; set; }

        public string PaymentMethod { get; set; }
        public string PaymentReference { get; set; } = string.Empty;

        // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        // public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        // public DateTime CreatedAt { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset? UpdatedAt { get; set; }
        // public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        public ICollection<BookingModel> Bookings { get; set; } = new List<BookingModel>();
    }
};

