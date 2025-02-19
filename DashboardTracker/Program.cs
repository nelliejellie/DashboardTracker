using DashboardTracker.Data;
using DashboardTracker.Repository;
using DashboardTracker.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace DashboardTracker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.File("logs/app-.log", rollingInterval: RollingInterval.Day)
                .CreateLogger();

                var builder = WebApplication.CreateBuilder(args);

                // Add services to the container.
                builder.Services.AddControllersWithViews();

                var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

                // Use the connection string as needed, for example, to configure a DbContext
                builder.Services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(connectionString));

                //add repository to the dependency injection container
                builder.Services.AddScoped<JobRepo>();
                // Register the JobCheckerService
                builder.Services.AddHttpClient();
                builder.Services.AddSingleton<IHostedService, JobCheckerService>();
                var app = builder.Build();


                // Configure the HTTP request pipeline.
                if (!app.Environment.IsDevelopment())
                {
                    app.UseExceptionHandler("/Home/Error");
                    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                    app.UseHsts();
                }

                app.UseHttpsRedirection();
                app.UseRouting();

                app.UseAuthorization();

                app.MapStaticAssets();
                app.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}")
                    .WithStaticAssets();

                app.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application start-up failed");
                throw;
            }
            finally
            {
                Log.CloseAndFlush();
            }
            // Configure Serilog
           
        }
    }
}
