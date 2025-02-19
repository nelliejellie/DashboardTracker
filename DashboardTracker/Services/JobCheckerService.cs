using DashboardTracker.Controllers;
using DashboardTracker.Repository;

namespace DashboardTracker.Services
{
    public class JobCheckerService : IHostedService, IDisposable
    {
        private Timer _timer;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly ILogger<JobCheckerService> _logger;

        public JobCheckerService(IHttpClientFactory httpClientFactory, IServiceScopeFactory serviceScopeFactory, ILogger<JobCheckerService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _serviceScopeFactory = serviceScopeFactory;
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(CheckJobStatus, null, TimeSpan.Zero, TimeSpan.FromMinutes(5));
            return Task.CompletedTask;
        }

        private async void CheckJobStatus(object state)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var jobRepo = scope.ServiceProvider.GetRequiredService<JobRepo>();
                var allJobs = await jobRepo.GetAllJobsAsync();
                foreach (var service in allJobs)
                {
                    if (DateTime.Now > service.lastRun && service.status == "stop")
                    {
                        var client = _httpClientFactory.CreateClient();
                        var response = await client.GetAsync(service.jobUrl);
                        if (response.IsSuccessStatusCode)
                        {
                            // Handle successful job start
                            _logger.LogInformation($"{service.name} has started");
                        }
                        else
                        {
                            // Handle failed job start
                            _logger.LogInformation($"{service.name} could not start");
                        }
                    }
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
