using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleaningServiceAPI.Modules.User.Models;
using CleaningServiceAPI.Modules.Booking.Models;
using CleaningServiceAPI.Modules.Cleaner.Models;
using CleaningServiceAPI.Modules.Payment.Models;
using CleaningServiceAPI.Modules.Subscription.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace CleaningServiceAPI.Data
{
    public class CleaningServiceDbContext : DbContext
    {
        public CleaningServiceDbContext(DbContextOptions<CleaningServiceDbContext> options) : base(options)
        {
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<CleanerModel> Cleaners { get; set; }
        public DbSet<SubscriptionPlan> SubscriptionPlans { get; set; }
        public DbSet<SubscriptionModel> Subscriptions { get; set; }
        public DbSet<BookingModel> Bookings { get; set; }
        public DbSet<CleanerAvailability> CleanerAvailabilities { get; set; }
        public DbSet<PaymentModel> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User configuration
            modelBuilder.Entity<UserModel>(entity =>
            {
                entity.HasIndex(e => e.Email).IsUnique();
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
            });

            // Cleaner configuration
            modelBuilder.Entity<CleanerModel>(entity =>
            {
                entity.HasIndex(e => e.Email).IsUnique();
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
                entity.Property(e => e.HourlyRate).HasPrecision(10, 2);
            });

            // Subscription configuration
            modelBuilder.Entity<SubscriptionModel>(entity =>
            {
                entity.HasOne(s => s.User)
                    .WithMany(u => u.Subscriptions)
                    .HasForeignKey(s => s.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(s => s.SubscriptionPlan)
                    .WithMany(sp => sp.Subscriptions)
                    .HasForeignKey(s => s.SubscriptionPlanId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
            });

            // Booking configuration
            modelBuilder.Entity<BookingModel>(entity =>
            {
                entity.HasOne(b => b.User)
                    .WithMany(u => u.Bookings)
                    .HasForeignKey(b => b.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(b => b.Subscription)
                    .WithMany(s => s.Bookings)
                    .HasForeignKey(b => b.SubscriptionId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(b => b.Cleaner)
                    .WithMany(c => c.Bookings)
                    .HasForeignKey(b => b.CleanerId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
            });

            // CleanerAvailability configuration
            modelBuilder.Entity<CleanerAvailability>(entity =>
            {
                entity.HasOne(ca => ca.Cleaner)
                    .WithMany(c => c.Availabilities)
                    .HasForeignKey(ca => ca.CleanerId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasIndex(e => new { e.CleanerId, e.DayOfWeek }).IsUnique();
            });

            // Payment configuration
            modelBuilder.Entity<PaymentModel>(entity =>
            {
                entity.HasOne(p => p.User)
                    .WithMany()
                    .HasForeignKey(p => p.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(p => p.Subscription)
                    .WithMany()
                    .HasForeignKey(p => p.SubscriptionId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(p => p.Booking)
                    .WithMany()
                    .HasForeignKey(p => p.BookingId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
            });

            // Seed data
            modelBuilder.Entity<SubscriptionPlan>().HasData(
                new SubscriptionPlan
                {
                    Id = 1,
                    Name = "Weekly Standard",
                    Description = "Standard cleaning service every week",
                    Price = 80.00m,
                    CleaningFrequencyDays = 7,
                    DurationHours = 3,
                    IsActive = true
                },
                new SubscriptionPlan
                {
                    Id = 2,
                    Name = "Bi-Weekly Standard",
                    Description = "Standard cleaning service every two weeks",
                    Price = 90.00m,
                    CleaningFrequencyDays = 14,
                    DurationHours = 4,
                    IsActive = true
                },
                new SubscriptionPlan
                {
                    Id = 3,
                    Name = "Monthly Deep Clean",
                    Description = "Deep cleaning service once a month",
                    Price = 150.00m,
                    CleaningFrequencyDays = 30,
                    DurationHours = 6,
                    IsActive = true
                }
            );
        }
    }

}