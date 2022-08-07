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
        // создаем контекст данных
        EmployeesCensusContext db = new EmployeesCensusContext();

        public ActionResult Index()
        {
            return View(db.Employees);
        }

        [HttpGet]
        public ActionResult Add()
        {
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
            
            var employee = db.Employees.Find(id);
            if (employee == null)            
                return HttpNotFound();
            
            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            db.Entry(employee).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var employee = db.Employees.Find(id);
            if (employee == null)            
                return HttpNotFound();
            
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var employee = db.Employees.Find(id);
            if (employee == null)
                return HttpNotFound();

            db.Employees.Remove(employee);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}