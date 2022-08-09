using EmployeesCensus.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeesCensus.Controllers
{
    public class HomeController : Controller
    {
        EmployeesCensusContext db = new EmployeesCensusContext();

        public ActionResult Index()
        {
            var employees = db.Employees
                .Include(e => e.Department)
                .Include(e => e.Experience)
                .Include(e => e.Experience.ProgrammingLanguage);

            return View(employees.ToList());
        }

        [HttpGet]
        public ActionResult Add()
        {
            var departments = new SelectList(db.Departments, "Id", "Name");
            ViewBag.Departments = departments;

            var programmingLanguages = new SelectList(db.ProgrammingLanguages, "Id", "Name");
            ViewBag.ProgrammingLanguages = programmingLanguages;

            return View();
        }

        [HttpPost]
        public ActionResult Add(Employee employee)
        {
            db.Entry(employee).State = EntityState.Added;
            db.SaveChanges();

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

            var departments = new SelectList(db.Departments, "Id", "Name");
            ViewBag.Departments = departments;

            var programmingLanguages = new SelectList(db.ProgrammingLanguages, "Id", "Name");
            ViewBag.ProgrammingLanguages = programmingLanguages;

            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            db.Entry(employee).State = EntityState.Modified;
            db.Entry(employee.Experience).State = EntityState.Modified;
            db.SaveChanges();
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
            var employee = db.Employees.Find(id);
            if (employee == null)
                return HttpNotFound();

            db.Employees.Remove(employee);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        private Employee ReturnEmployee(int id)
        {
            return db.Employees
                .Include(e => e.Department)
                .Include(e => e.Experience)
                .Include(e => e.Experience.ProgrammingLanguage)
                .FirstOrDefault(e => e.Id == id);
        }
    }
}