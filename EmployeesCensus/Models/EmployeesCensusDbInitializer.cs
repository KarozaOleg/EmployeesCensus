using System.Data.Entity;

namespace EmployeesCensus.Models
{
    public class EmployeesCensusDbInitializer : DropCreateDatabaseAlways<EmployeesCensusContext>
    {
        protected override void Seed(EmployeesCensusContext db)
        {
            db.Departments.Add(new Department { Name = "ИТ1", Floor = 1 });
            db.Departments.Add(new Department { Name = "ИТ2", Floor = 2 });

            db.Employees.Add(new Employee { FirstName = "Петр", LastName = "Осипов", Age = 18, Sex = Sex.Male, DepartmentId = 1 });
            db.Employees.Add(new Employee { FirstName = "Михаил", LastName = "Теселки", Age = 48, Sex = Sex.Male, DepartmentId = 1 });
            db.Employees.Add(new Employee { FirstName = "Анна", LastName = "Петров", Age = 23, Sex = Sex.Female, DepartmentId = 1 });

            base.Seed(db);
        }
    }
}