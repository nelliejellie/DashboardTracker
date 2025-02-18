using System.Diagnostics;
using DashboardTracker.Models;
using DashboardTracker.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DashboardTracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly JobRepo _jobRepo;

        public HomeController(ILogger<HomeController> logger, JobRepo jobRepo)
        {
            _logger = logger;
            _jobRepo = jobRepo;
        }

        public async Task<IActionResult> Index(string searchString, string statusFilter)
        {
            try
            {
                var jobs = await _jobRepo.GetAllJobsAsync();

                if (!string.IsNullOrEmpty(searchString))
                {
                    jobs = jobs.Where(j => j.name != null && j.name.Contains(searchString, StringComparison.OrdinalIgnoreCase));
                }

                if (!string.IsNullOrEmpty(statusFilter))
                {
                    jobs = jobs.Where(j => j.status != null && j.status.Equals(statusFilter, StringComparison.OrdinalIgnoreCase));
                }

                var viewModel = new JobViewModel { Jobs = jobs };
                return View(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all jobs.");
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            var job = await _jobRepo.GetJobByIdAsync(id);
            if (job == null)
            {
                return NotFound();
            }
            return View(job);
        }

        public IActionResult Apps()
        {
            ViewData["ActivePage"] = "Apps";
            return View("ComingSoon");
        }

        public IActionResult Apis()
        {
            ViewData["ActivePage"] = "APIs";
            return View("ComingSoon");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
