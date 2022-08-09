using EmployeesCensus.ActivityTracking;
using EmployeesCensus.Authentication;
using EmployeesCensus.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace EmployeesCensus.Controllers
{
    [BasicAuthenticationAttribute]
    [UserTrackerLogAttribute]
    public class HomeController : Controller
    {
        EmployeesCensusContext Db = new EmployeesCensusContext();

        public ActionResult Index()
        {
            var employees = ReturnEmployees().ToList();
            return View(employees);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var departments = new SelectList(Db.Departments, "Id", "Name");
            ViewBag.Departments = departments;

            var programmingLanguages = new SelectList(Db.ProgrammingLanguages, "Id", "Name");
            ViewBag.ProgrammingLanguages = programmingLanguages;

            return View();
        }

        [HttpPost]
        public ActionResult Add(Employee employee)
        {
            Db.Entry(employee).State = EntityState.Added;
            Db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)            
                return HttpNotFound();
            
            var employee = ReturnEmployee(id.Value);
            if (employee == null)            
                return HttpNotFound();

            var departments = new SelectList(Db.Departments, "Id", "Name");
            ViewBag.Departments = departments;

            var programmingLanguages = new SelectList(Db.ProgrammingLanguages, "Id", "Name");
            ViewBag.ProgrammingLanguages = programmingLanguages;

            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            Db.Entry(employee).State = EntityState.Modified;
            Db.Entry(employee.Experience).State = EntityState.Modified;
            Db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if(id == null)
                return HttpNotFound();

            var employee = ReturnEmployee(id.Value);
            if (employee == null)            
                return HttpNotFound();
            
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id.HasValue == false)
                return HttpNotFound();

            var employee = ReturnEmployee(id.Value);
            if (employee == null)
                return HttpNotFound();

            employee.IsDeleted = true;
            Db.Entry(employee).State = EntityState.Modified;
            Db.SaveChanges();

            return RedirectToAction("Index");
        }

        private IQueryable<Employee> ReturnEmployees()
        {
            return Db.Employees
                .Include(e => e.Department)
                .Include(e => e.Experience)
                .Include(e => e.Experience.ProgrammingLanguage)
                .Where(e => e.IsDeleted == false);
        }

        private Employee ReturnEmployee(int id)
        {
            return ReturnEmployees().FirstOrDefault(e => e.Id == id);
        }
    }
}