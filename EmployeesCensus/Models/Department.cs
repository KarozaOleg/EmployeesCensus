using System.ComponentModel.DataAnnotations;

namespace EmployeesCensus.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Floor { get; set; }
    }
}