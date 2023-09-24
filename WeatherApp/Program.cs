using Hangfire;
using Hangfire.MySql;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using WeatherApp.Data;
using WeatherApp.Jobs;
using WeatherApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<WeatherService>();
builder.Services.AddScoped<IWeatherAppDbContext,WeatherAppDbContext>();
builder.Services.AddScoped<IWeatherService, WeatherService>();

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<WeatherAppDbContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddHangfire(configuration => configuration
.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
.UseSimpleAssemblyNameTypeSerializer()
.UseRecommendedSerializerSettings()
.UseStorage(new MySqlStorage(builder.Configuration.GetConnectionString("DefaultConnection"), new MySqlStorageOptions
{
    QueuePollInterval = TimeSpan.FromSeconds(15)
})));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseHangfireServer(new BackgroundJobServerOptions { SchedulePollingInterval = TimeSpan.FromSeconds(1) });
app.UseHangfireDashboard();

// Schedule the WeatherUpdateJob to run every 1 hour
RecurringJob.AddOrUpdate<WeatherUpdateJob>(x => x.UpdateWeatherData("London"), Cron.Hourly);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
