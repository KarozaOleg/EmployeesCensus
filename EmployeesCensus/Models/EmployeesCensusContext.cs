using System.Data.Entity;

namespace EmployeesCensus.Models
{
    public class EmployeesCensusContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        public DbSet<EmployeeExperience> EmployeesExperience { get; set; }
    }
}