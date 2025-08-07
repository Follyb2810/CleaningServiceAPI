using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using CleaningServiceAPI.Data;
using CleaningServiceAPI.Modules.User.Models;

namespace CleaningServiceAPI.Extensions
{
    public static class IdentityExtension
    {
        public static IServiceCollection AddIdentity(this IServiceCollection _services)
        {
            _services.AddIdentity<UserModel, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredLength = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.SignIn.RequireConfirmedAccount = false;
                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<CleaningServiceDbContext>()
            .AddDefaultTokenProviders();

            return _services;
        }
    }

}