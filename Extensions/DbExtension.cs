using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using CleaningServiceAPI.Common;

namespace CleaningServiceAPI.Extensions
{
    public static class DbExtension
    {
        public static IServiceCollection AddDb(this IServiceCollection _service)
        {
            _service.AddSingleton(sp =>
    sp.GetRequiredService<IOptions<JwtOptions>>().Value
    );
            // _service.AddDbContext<DataContext>(options =>
            // {
            //     var connectionString = builder.Configuration.GetConnectionString("follydb");
            //     options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            // });
            return _service;
        }
    }
}