using EmployeesCensus.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeesCensus.Controllers
{
    public class UsersController : Controller
    {
        EmployeesCensusContext db = new EmployeesCensusContext();

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
        public ActionResult Add(User user)
        {
            db.Entry(user).State = EntityState.Added;
            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}