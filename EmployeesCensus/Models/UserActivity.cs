namespace EmployeesCensus.Models
{
    public class UserActivity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Action { get; set; }
    }
}