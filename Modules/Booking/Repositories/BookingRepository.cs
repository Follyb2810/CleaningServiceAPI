using CleaningServiceAPI.Contract;
using CleaningServiceAPI.Modules.Booking.Models;
using CleaningServiceAPI.Modules.Booking.Repositories;
using CleaningServiceAPI.Modules.Booking.DTOs;
using CleaningServiceAPI.Data;
using Microsoft.EntityFrameworkCore;
using CleaningServiceAPI.Modules.Cleaner.Models;
using CleaningServiceAPI.Modules.Booking.Mappers;
using System.Linq;


namespace CleaningServiceAPI.Modules.Booking.Repositories
{
    public class BookingRepository : Repository<BookingModel>, IBookingRepository
    {
        private readonly CleaningServiceDbContext _context;
        public const int MaxRating = 5;
        public const double TaxRate = 0.075;
        public BookingRepository(CleaningServiceDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<BookingModel>> GetUpcomingBookingsForUser(string userId)
        {
            return await _context.Bookings
                .Where(b => b.UserId == userId && b.ScheduledDate > DateTime.Now)
                .ToListAsync();
        }
        public async Task<IEnumerable<BookingModel>> GetBookingsByUserAsync(int userId)
        {
            return await _context.Bookings.Include(b => b.Cleaner)
                                    .Include(b => b.Subscription)
                                    .Where(b => b.UserId == userId.ToString())
                                    .OrderByDescending(b => b.ScheduledDate)
                                    .ToListAsync();
        }
        public async Task<IEnumerable<BookingModel>> GetBookingsByCleanerAsync(int cleanerId)
        {
            return await _context.Bookings.Include(b => b.Cleaner)
                .Include(b => b.Subscription)
                .Where(b => b.CleanerId == cleanerId)
                .OrderBy(b => b.ScheduledDate).ToListAsync();
        }
        public async Task<IEnumerable<BookingModel>> GetBookingsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Bookings.Include(b => b.User).Include(b => b.Cleaner)
            .Where(b => b.ScheduledDate >= startDate && b.ScheduledDate <= endDate)
            .OrderBy(b => b.ScheduledDate).ToListAsync();
        }
        public async Task<BookingModel> AssignCleanerAsync(int bookingId, int cleanerId)
        {
            var booking = await _context.Bookings.FindAsync(bookingId);
            if (booking == null) return null;
            var cleaner = await _context.Cleaners.FindAsync(cleanerId);
            if (cleaner != null || !cleaner.IsAvailable) return null;
            booking.CleanerId = cleanerId;
            booking.UpdatedAt = DateTimeOffset.UtcNow;
            // booking.UpdateAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return await GetBookingByIdAsync(bookingId);

        }
        public async Task<BookingModel> GetBookingByIdAsync(int id)
        {
            return await _context.Bookings
                .Include(b => b.User)
                .Include(b => b.Cleaner)
                .Include(b => b.Subscription)
                .FirstOrDefaultAsync(b => b.Id == id);
        }
        public async Task<BookingModel> CompleteBookingAsync(BookingCompletionDto dto)
        {
            var booking = await FindByIdAsync(dto.BookingId);
            if (booking == null) return null;
            booking.MapCompletionToExisting(dto);

            await _context.SaveChangesAsync();
            return booking;

        }
        public async Task<BookingModel> CancelBookingAsync(int bookingId)
        {
            var booking = await FindByIdAsync(bookingId);
            if (booking == null) return null;
            booking.Status = BookingStatus.Cancelled;
            booking.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return booking;
        }
        public async Task<IEnumerable<CleanerModel>> GetAvailableCleanersAsync(DateTime date, TimeSpan time, int durationHours)
        {
            var dayOfWeek = date.DayOfWeek;
            var endTime = time.Add(TimeSpan.FromHours(durationHours));
            return await _context.Cleaners
    .Where(c => c.IsAvailable)
    .Where(c => c.Availabilities.Any(a =>
        a.DayOfWeek == dayOfWeek &&
        a.IsAvailable &&
        a.StartTime <= time &&
        a.EndTime >= endTime))
    .Where(c => !c.Bookings.Any(b =>
        b.ScheduledDate.Date == date.Date &&
        b.Status == BookingStatus.Scheduled &&
        ((b.ScheduledTime <= time && b.ScheduledTime.Add(TimeSpan.FromHours(b.DurationHours)) > time) ||
         (b.ScheduledTime < endTime && b.ScheduledTime.Add(TimeSpan.FromHours(b.DurationHours)) >= endTime))))
    .ToListAsync();
        }
    }
}