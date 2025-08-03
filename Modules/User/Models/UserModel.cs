using CleaningServiceAPI.Modules.Subscription.Models;
using CleaningServiceAPI.Modules.Booking.Models;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace CleaningServiceAPI.Modules.User.Models
{
    public enum UserRole { Admin, Client, Cleaner }
    public class UserModel
    {


        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public string UserName { get; set; } = null!;

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }= string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public UserRole Role { get; set; } = UserRole.Client;
        public string Address { get; set; }= string.Empty;
        public string City { get; set; }= string.Empty;
        public string PostalCode { get; set; }= string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        public ICollection<SubscriptionModel> Subscriptions { get; set; } = new List<SubscriptionModel>();
        public ICollection<BookingModel> Bookings { get; set; } = new List<BookingModel>();

    }
}
