using EmployeesCensus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeesCensus.Controllers
{
    public class HomeController : Controller
    {
        // создаем контекст данных
        EmployeeContext db = new EmployeeContext();

        public ActionResult Index()
        {
            // получаем из бд все объекты Book
            IEnumerable<Employee> employees = db.Employees;
            // передаем все объекты в динамическое свойство Books в ViewBag
            ViewBag.Employees = employees;
            // возвращаем представление
            return View();
        }        
    }
}