using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;
using Scratch.Data;
using Scratch.ServiceDelegates;

namespace Scratch.Web
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // Set up component factory
            Components.Access = () =>
            {
                const string key = "Scratch.Components";

                var items = HttpContext.Current.Items;

                if (!items.Contains(key))
                {
                    items.Add(key, new Components
                    {
                        Cache = new Cache(),
                        Users = new Users()
                    });
                }

                return (Components)items[key];
            };
        }
    }
}