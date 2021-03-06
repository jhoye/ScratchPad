﻿using System.Web.Mvc;
using System.Web.Routing;

namespace Scratch.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("PageActions", "Page/{action}", new
            {
                controller = "Page", 
                action = "Edit"
            });

            routes.MapRoute(
                "About",
                "Admin/About",
                new
                {
                    controller = "Admin",
                    action = "About"
                });

            routes.MapRoute(
                "Admin", 
                "Admin/{controller}/{action}/{id}", 
                new
                {
                    controller = "Admin",
                    action = "Index",
                    id = UrlParameter.Optional
                });

            routes.MapRoute(
                "Idea",
                "Idea/Collect",
                new
                {
                    controller = "Idea",
                    action = "Collect"
                });

            routes.MapRoute(
                "Treeview",
                "Treeview/{action}/{id}",
                new
                {
                    controller = "Treeview",
                    action = "Index",
                    id = UrlParameter.Optional
                });

            routes.MapRoute("Login", "Login", new
            {
                controller = "Authentication",
                action = "Login"
            });

            routes.MapRoute("Logout", "Logout", new
            {
                controller = "Authentication",
                action = "Logout"
            });

            routes.MapRoute("Default", "{slug}", new
            {
                controller = "Page", 
                action = "Get", 
                slug = UrlParameter.Optional
            });

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Page", action = "Index", id = UrlParameter.Optional }
            //);
        }
    }
}
