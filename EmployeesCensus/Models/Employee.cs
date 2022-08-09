namespace EmployeesCensus.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Sex Sex { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public EmployeeExperience Experience { get; set; }
    }
}