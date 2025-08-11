using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleaningServiceAPI.Modules.Booking.Models;
using CleaningServiceAPI.Contract;
using CleaningServiceAPI.Modules.Booking.DTOs;
using CleaningServiceAPI.Modules.Cleaner.Models;


namespace CleaningServiceAPI.Modules.Booking.Repositories
{
    public interface IBookingRepository : IBaseRepository<BookingModel>
    {
        Task<IEnumerable<BookingModel>> GetUpcomingBookingsForUser(string userId);
        Task<BookingModel> CreateBookingAsync(CreateBookingDto dto);
        Task<BookingModel> GetBookingByIdAsync(string id);
        Task<IEnumerable<BookingModel>> GetBookingsByUserAsync(string userId);
        Task<IEnumerable<BookingModel>> GetBookingsByCleanerAsync(string cleanerId);
        Task<IEnumerable<BookingModel>> GetBookingsByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<BookingModel> AssignCleanerAsync(string bookingId, string cleanerId);
        Task<BookingModel> CompleteBookingAsync(BookingCompletionDto dto);
        Task<BookingModel> CancelBookingAsync(string bookingId);
        Task<IEnumerable<CleanerModel>> GetAvailableCleanersAsync(DateTime date, TimeSpan time, int durationHours);
    }
}