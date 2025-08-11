using Microsoft.AspNetCore.Mvc;
using CleaningServiceAPI.Modules.Booking.Services;
using CleaningServiceAPI.Modules.Booking.DTOs;
using CleaningServiceAPI.Modules.Booking.Models;
using CleaningServiceAPI.Modules.Cleaner.Models;
using CleaningServiceAPI.Modules.Booking.Mappers;
using CleaningServiceAPI.Modules.Booking.Repositories;

namespace CleaningServiceAPI.Modules.Booking.Services
{
    public class BookingService
    {
        private readonly IBookingRepository _bookingRepository;
        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }
        // public object First()
        // {
        //     return new { message = "Booking service works!" };
        // }
        public Task<object> First()
        {
            return Task.FromResult((object)new { message = "Booking service works!" });
        }

        public async Task<BookingModel> CreateBookingAsync(CreateBookingDto dto)
        {
            // return await _bookingRepository.CreateAsync(dto);
            return await _bookingRepository.CreateBookingAsync(dto);

        }

        public async Task<IEnumerable<BookingModel>> GetUpcomingBookingsForUser(string userId)
        {
            return await _bookingRepository.GetUpcomingBookingsForUser(userId);
        }
        public async Task<IEnumerable<BookingModel>> GetBookingsByUserAsync(string userId)
        {
            return await _bookingRepository.GetBookingsByUserAsync(userId);
        }
        public async Task<IEnumerable<BookingModel>> GetBookingsByCleanerAsync(string cleanerId)
        {
            return await _bookingRepository.GetBookingsByCleanerAsync(cleanerId);
        }
        public async Task<BookingModel> AssignCleanerAsync(string bookingId, string cleanerId)
        {
            return await _bookingRepository.AssignCleanerAsync(bookingId, cleanerId);
        }
        public async Task<BookingModel> GetBookingByIdAsync(string id)
        {
            return await _bookingRepository.GetBookingByIdAsync(id);
        }
        public async Task<BookingModel> CompleteBookingAsync(BookingCompletionDto dto)
        {
            return await _bookingRepository.CompleteBookingAsync(dto);
        }
        public async Task<BookingModel> CancelBookingAsync(string bookingId)
        {
            return await _bookingRepository.CancelBookingAsync(bookingId);
        }
        public async Task<IEnumerable<CleanerModel>> GetAvailableCleanersAsync(DateTime date, TimeSpan time, int durationHours)
        {
            return await _bookingRepository.GetAvailableCleanersAsync(date, time, durationHours);
        }
        public async Task<IEnumerable<BookingModel>> GetBookingsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _bookingRepository.GetBookingsByDateRangeAsync(startDate, endDate);
        }


    }
}