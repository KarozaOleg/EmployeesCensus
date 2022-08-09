using System;

namespace EmployeesCensus.Models
{
    public class UserActivity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public DateTime Timestamp { get; set; }
    }
}