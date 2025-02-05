namespace DashboardTracker.Models
{
    public class Job
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? jobUrl { get; set; }
        public int interval { get; set; }
        public string? intervalUnit { get; set; }
        public string? status { get; set; }
        public bool? doNotification { get; set; }
        public string? doNotificationEmail { get; set; }
        public string? doNotificationEmailCC { get; set; }
        public string? doNotificationEmailBC { get; set; }
        public bool? repeatUntillSuccess { get; set; }
        public DateTime? lastRun { get; set; }
        public DateTime? nextRun { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
        public DateTime? createdD { get; set; }
        public int? createdDBy { get; set; }
        public string? createdByName { get; set; }
        public DateTime? edited { get; set; }
        public int? editedBy { get; set; }
        public string? editedByName { get; set; }
        public string? appName { get; set; }
    
}
}
