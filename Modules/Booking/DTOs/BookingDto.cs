using CleaningServiceAPI.Modules.Booking.Models;

namespace CleaningServiceAPI.Modules.Booking.DTOs
{
    public class BookingDto
    {
        public string Id { get; set; }
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
        public string? SubscriptionId { get; set; }
        public DateTimeOffset ScheduledDate { get; set; }
        public TimeSpan ScheduledTime { get; set; }
        public int DurationHours { get; set; }
        public string ServiceAddress { get; set; }
        public string? SpecialInstructions { get; set; }
        public BookingType Type { get; set; }
        public decimal Price { get; set; }
    }
    public class BookingCompletionDto
    {
        public string BookingId { get; set; }
        public string? CleanerNotes { get; set; }
        public string? Rating { get; set; }
        public string? CustomerFeedback { get; set; }
    }
};
