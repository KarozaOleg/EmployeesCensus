using System.Data.Entity;

namespace EmployeesCensus.Models
{
    public class EmployeeDbInitializer : DropCreateDatabaseAlways<EmployeeContext>
    {
        protected override void Seed(EmployeeContext db)
        {
            db.Employees.Add(new Employee { FirstName = "Петр", LastName = "Осипов", Age = 18, Sex = Sex.Male });
            db.Employees.Add(new Employee { FirstName = "Михаил", LastName = "Теселки", Age = 48, Sex = Sex.Male });
            db.Employees.Add(new Employee { FirstName = "Анна", LastName = "Петров", Age = 23, Sex = Sex.Female });

            base.Seed(db);
        }
    }
}