using DashboardTracker.Models;
using Microsoft.EntityFrameworkCore;


namespace DashboardTracker.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
    : base(options)
        {
        }

        public DbSet<Job> Jobs { get; set; }
    }

    
}
