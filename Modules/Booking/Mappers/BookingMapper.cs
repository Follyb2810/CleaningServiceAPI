using System;
using CleaningServiceAPI.Modules.Booking.Models;
using CleaningServiceAPI.Modules.Booking.DTOs;
namespace CleaningServiceAPI.Modules.Booking.Mappers
{
    public static class BookingMapper
    {
        public static BookingModel ToDto(BookingModel entity)
        {
            return new BookingModel
            {
                UserId = entity.UserId,
                SubscriptionId = entity.SubscriptionId,
                ScheduledDate = entity.ScheduledDate,
                DurationHours = entity.DurationHours,
                ServiceAddress = entity.ServiceAddress,
                SpecialInstructions = entity.SpecialInstructions,
                Type = entity.Type,
                Price = entity.Price,
            };
        }
        public static BookingModel ToModel(CreateBookingDto entity)
        {
            return new BookingModel
            {
                UserId = entity.UserId,
                SubscriptionId = entity.SubscriptionId,
                ScheduledDate = entity.ScheduledDate,
                DurationHours = entity.DurationHours,
                ServiceAddress = entity.ServiceAddress,
                SpecialInstructions = entity.SpecialInstructions,
                Type = entity.Type,
                Price = entity.Price,


            };
        }
        public static List<BookingDto> ToDtoList(IEnumerable<BookingModel> bookings)
        {
            // return booking.Select(ToDto).ToList();
            var bookingDtos = bookings
                .Select(b => new BookingDto
                {
                    Id = b.Id,
                    UserId = b.UserId,
                    ScheduledTime = b.ScheduledTime,
                })
                .ToList();
            return bookingDtos;
        }
        public static void MapCompletionToExisting(this BookingModel booking, BookingCompletionDto dto)
        {
            booking.Status = BookingStatus.Completed;
            booking.CompletedAt = DateTimeOffset.UtcNow;
            // booking.CompletedAt = DateTime.UtcNow;
            booking.CleanerNotes = dto.CleanerNotes;
            booking.Rating = dto.Rating;
            booking.CustomerFeedback = dto.CustomerFeedback;
            booking.UpdatedAt = DateTimeOffset.UtcNow;
            // booking.UpdatedAt = DateTime.UtcNow;
        }

    }
}