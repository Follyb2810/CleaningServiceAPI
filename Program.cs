using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
// using Microsoft.OpenApi.Models;
using CleaningServiceAPI.Common;
using Microsoft.Extensions.Options;
using CleaningServiceAPI.Extensions;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// builder.Services.AddOpenApi();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();
builder.Services.AddSwagger();

builder.Services.AddWithCors();
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("Jwt"));
builder.Services.AddDb();
// builder.Services.AddTransient<UserMiddleware>();

// builder.Services.AddScoped<TokenService>();
// builder.Services.AddControllers();
// builder.Services.AddDbContext<AppDbContext>(...);
// builder.Services.AddUserModule();
// services.AddScoped(typeof(IBaseRepository<>), typeof(Repository<>));

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     // app.MapOpenApi();
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }
if (app.Environment.IsDevelopment())
{
    Console.WriteLine($"Environment: {app.Environment.EnvironmentName}");

    app.UseSwagger();
    app.UseSwaggerUI();
}


// app.UseMiddleware<UserMiddleware>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors("AllowAngular");

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

// app.MapGet("/", () => Results.Redirect("/swagger"));
app.MapGet("/", () => "home sweet home");

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");
app.MapControllers();
app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
