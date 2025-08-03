using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using CleaningServiceAPI.Modules.User.Models;
using CleaningServiceAPI.Modules.Cleaner.Models;
using CleaningServiceAPI.Modules.Subscription.Models;

namespace CleaningServiceAPI.Modules.Booking.Models
{
    public enum BookingStatus
    {
        Scheduled,
        InProgress,
        Completed,
        Cancelled,
        NoShow
    }

    public enum BookingType
    {
        OneTime,
        Subscription
    }

    public class BookingModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public UserModel User { get; set; }

        public int? SubscriptionId { get; set; } // Null for one-time bookings
        public SubscriptionModel? Subscription { get; set; }

        public int? CleanerId { get; set; } // Assigned cleaner
        public CleanerModel? Cleaner { get; set; }

        public DateTime ScheduledDate { get; set; }
        public TimeSpan ScheduledTime { get; set; }
        public int DurationHours { get; set; }

        public string ServiceAddress { get; set; }
        public string SpecialInstructions { get; set; }

        public BookingStatus Status { get; set; } = BookingStatus.Scheduled;
        public BookingType Type { get; set; } // OneTime or Subscription

        // [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        public DateTime? CompletedAt { get; set; }
        public string? CleanerNotes { get; set; }
        public int? Rating { get; set; } // 1-5 stars
        public string? CustomerFeedback { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
};