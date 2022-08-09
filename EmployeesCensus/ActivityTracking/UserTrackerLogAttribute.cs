using EmployeesCensus.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace EmployeesCensus.ActivityTracking
{
    public class UserTrackerLogAttribute : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            try
            {
                var auth = filterContext.HttpContext.Request.Headers["Authorization"];
                if (string.IsNullOrEmpty(auth))
                    return;
                var cred = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(auth.Substring(6))).Split(':');
                if (cred.Length < 2)
                    return;
                var userId = ReturnUserId(cred[0]);
                if (userId.HasValue == false)
                    return;

                var actionDescriptor = filterContext.ActionDescriptor;

                SaveActionIntoDb(userId.Value, actionDescriptor.ControllerDescriptor.ControllerName, actionDescriptor.ActionName);
            }
            finally
            {
                base.OnActionExecuted(filterContext);
            }
        }

        private int? ReturnUserId(string username)
        {
            using (var db = new EmployeesCensusContext())
            {
                return db.Users
                .Where(u => u.Username == username)
                .Select(u => u.Id)
                .SingleOrDefault();
            }
        }

        private void SaveActionIntoDb(int userId, string controller, string action)
        {
            var userActivity = new UserActivity()
            {
                UserId = userId,
                Controller = controller,
                Action = action,
                Timestamp = DateTime.Now
            };
            using (var db = new EmployeesCensusContext())
            {
                db.UserActivity.Add(userActivity);
                db.SaveChanges();
            }
        }
    }
}