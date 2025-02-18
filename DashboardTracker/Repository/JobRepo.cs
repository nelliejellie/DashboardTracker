using DashboardTracker.Data;
using DashboardTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace DashboardTracker.Repository
{
    public class JobRepo
    {
        private readonly AppDbContext _context;

        public JobRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Job>> GetAllJobsAsync()
        {
            return await _context.Jobs.ToListAsync();
        }

        public async Task<Job?> GetJobByIdAsync(int id)
        {
            return await _context.Jobs.FindAsync(id);
        }
    }
}
