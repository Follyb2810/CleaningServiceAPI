using CleaningServiceAPI.Modules.Booking.Models;

namespace CleaningServiceAPI.Modules.Booking.DTOs
{
    public class BookingDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string SubscriptionId { get; set; }
        public TimeSpan ScheduledTime { get; set; }
        public string? SpecialInstructions { get; set; }
        public BookingType Type { get; set; }
        public decimal Price { get; set; }

    }
    public class CreateBookingDto
    {
        public string UserId { get; set; }
        public int? SubscriptionId { get; set; }
        public DateTime ScheduledDate { get; set; }
        public TimeSpan ScheduledTime { get; set; }
        public int DurationHours { get; set; }
        public string ServiceAddress { get; set; }
        public string? SpecialInstructions { get; set; }
        public BookingType Type { get; set; }
        public decimal Price { get; set; }
    }
    public class BookingCompletionDto
    {
        public int BookingId { get; set; }
        public string? CleanerNotes { get; set; }
        public int? Rating { get; set; }
        public string? CustomerFeedback { get; set; }
    }
};
