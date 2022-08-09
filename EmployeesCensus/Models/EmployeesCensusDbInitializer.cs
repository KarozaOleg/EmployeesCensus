using System.Data.Entity;

namespace EmployeesCensus.Models
{
    public class EmployeesCensusDbInitializer : DropCreateDatabaseAlways<EmployeesCensusContext>
    {
        protected override void Seed(EmployeesCensusContext db)
        {
            db.Departments.Add(new Department { Id = 1, Name = "ИТ1", Floor = 1 });
            db.Departments.Add(new Department { Id = 2, Name = "ИТ2", Floor = 1 });

            //db.Employees.Add(new Employee { Id = 1, FirstName = "Петр", LastName = "Осипов", Age = 18, Sex = Sex.Male, DepartmentId = 1 });

            db.ProgrammingLanguages.Add(new ProgrammingLanguage { Id = 1, Name = "C" });
            db.ProgrammingLanguages.Add(new ProgrammingLanguage { Id = 2, Name = "C#" });
            db.ProgrammingLanguages.Add(new ProgrammingLanguage { Id = 3, Name = "C++" });

            //db.EmployeesExperience.Add(new EmployeeExperience { EmployeeExperienceId = 1, ProgrammingLanguageId = 1 });

            //db.Departments.Add(new Department { Name = "ИТ1", Floor = 1 });
            //db.Departments.Add(new Department { Name = "ИТ2", Floor = 2 });
            //db.Departments.Add(new Department { Name = "ИТ3", Floor = 2 });

            //db.ProgrammingLanguages.Add(new ProgrammingLanguage { Name = "C" });
            //db.ProgrammingLanguages.Add(new ProgrammingLanguage { Name = "C++" });
            //db.ProgrammingLanguages.Add(new ProgrammingLanguage { Name = "Go" });
            //db.ProgrammingLanguages.Add(new ProgrammingLanguage { Name = "Python" });

            //db.EmployeesExperience.Add(new EmployeeExperience { EmployeeId = 0, ProgrammingLanguageId = 0 });
            //db.EmployeesExperience.Add(new EmployeeExperience { EmployeeId = 1, ProgrammingLanguageId = 1 });
            //db.EmployeesExperience.Add(new EmployeeExperience { EmployeeId = 2, ProgrammingLanguageId = 2 });

            //db.Employees.Add(new Employee { FirstName = "Петр", LastName = "Осипов", Age = 18, Sex = Sex.Male, DepartmentId = 0, ExperienceId = 0 });
            //db.Employees.Add(new Employee { FirstName = "Михаил", LastName = "Теселки", Age = 48, Sex = Sex.Male, DepartmentId = 1, ExperienceId = 1 });
            //db.Employees.Add(new Employee { FirstName = "Анна", LastName = "Петров", Age = 23, Sex = Sex.Female, DepartmentId = 2, ExperienceId = 1 });

            base.Seed(db);
        }
    }
}