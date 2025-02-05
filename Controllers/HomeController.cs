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

        public async Task<IActionResult> Index()
        {
            var jobs = await _jobRepo.GetAllJobsAsync();
            var viewModel = new JobViewModel { Jobs = jobs };
            return View(viewModel);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
