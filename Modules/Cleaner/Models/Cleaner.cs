using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using CleaningServiceAPI.Modules.Booking.Models;
namespace CleaningServiceAPI.Modules.Cleaner.Models
{
    public class CleanerModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        public string Specialties { get; set; } = string.Empty;
        public bool IsAvailable { get; set; } = true;
        public decimal HourlyRate { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        public ICollection<BookingModel> Bookings { get; set; } = new List<BookingModel>();
        public ICollection<CleanerAvailability> Availabilities { get; set; } = new List<CleanerAvailability>();

    }
    public class CleanerAvailability
    {
        public int Id { get; set; }

        public int CleanerId { get; set; }
        public CleanerModel Cleaner { get; set; }

        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public bool IsAvailable { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
};