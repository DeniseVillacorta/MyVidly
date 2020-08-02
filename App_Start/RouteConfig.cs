using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "MoviewView",
               url: "Movie/Details/{id}",
               defaults: new { controller = "Movie", action = "Details", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "CustomerView",
               url: "Customer/Details/{id}",
               defaults: new { controller = "Customer", action = "Details", id = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
