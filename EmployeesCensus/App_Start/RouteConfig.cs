using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EmployeesCensus
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "UsersAdding",
                url: "users/add",
                defaults: new { controller = "Users", action = "Add" }
            );

            routes.MapRoute(
                name: "AutocompleteSearch",
                url: "AutocompleteSearch/{action}/{id}",
                defaults: new { controller = "AutocompleteSearch", action = "Add", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "HomeIsDeafultController",
                url: "{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );            
        }
    }
}
