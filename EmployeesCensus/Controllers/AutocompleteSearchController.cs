using EmployeesCensus.Models;
using System.Linq;
using System.Web.Mvc;

namespace EmployeesCensus.Controllers
{
    [AllowAnonymous]
    public class AutocompleteSearchController : Controller
    {
        EmployeesCensusContext db = new EmployeesCensusContext();

        public ActionResult FirstName(string term)
        {
            var termInLowerCase = term.ToLower();
            var prefilledFirstName = db.Employees
               .Where(a => a.FirstName.ToLower().Contains(termInLowerCase))
               .Select(a => new { value = a.FirstName })
               .Distinct();

            return Json(prefilledFirstName, JsonRequestBehavior.AllowGet);
        }
    }
}