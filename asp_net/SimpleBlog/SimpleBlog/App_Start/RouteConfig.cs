using SimpleBlog.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SimpleBlog
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var namespaces = new[] { typeof(PostsController).Namespace };

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Login", "login", new { Controller = "Auth", action = "login" }, namespaces);
            routes.MapRoute("Logout", "logout", new { Controller = "Auth", action = "logout" }, namespaces);
            routes.MapRoute("User", "User", new { Controller = "Users", action = "Index" }, namespaces);
            // map route 
            // new {} : anonymous object
            routes.MapRoute("Home", "", new { Controller = "Posts", Action = "Index" }, namespaces); 
        }
    }
}
