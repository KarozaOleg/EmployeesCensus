using EmployeesCensus.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace EmployeesCensus.Authentication
{
    public class BasicAuthenticationAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var auth = filterContext.HttpContext.Request.Headers["Authorization"];
            if (string.IsNullOrEmpty(auth) == false)
            {
                var cred = System.Text.Encoding.ASCII.GetString(Convert.FromBase64String(auth.Substring(6))).Split(':');
                var user = new { Name = cred[0], Pass = cred[1] };
                using (var db = new EmployeesCensusContext())
                {
                    var isUserExists = db.Users
                        .AsNoTracking()
                        .Any(u => u.Username.Equals(user.Name) && u.Password.Equals(user.Pass));
                    if (isUserExists)
                        return;
                }
            }
            filterContext.HttpContext.Response.AddHeader("WWW-Authenticate", String.Format("Basic realm=\"{0}\"", "BasicRealm"));
            filterContext.Result = new HttpUnauthorizedResult();
        }
    }
}