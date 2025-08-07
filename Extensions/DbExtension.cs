using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using CleaningServiceAPI.Common;
using CleaningServiceAPI.Modules.User.Models;
using Microsoft.AspNetCore.Identity;
using CleaningServiceAPI.Data;


namespace CleaningServiceAPI.Extensions
{
    public static class DbExtension
    {
        public static IServiceCollection AddDb(this IServiceCollection _service, IConfiguration configuration)
        {
            _service.AddSingleton(sp =>
                sp.GetRequiredService<IOptions<JwtOptions>>().Value
            );

            _service.AddDbContext<CleaningServiceDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
            );

            return _service;
        }
    }
}


