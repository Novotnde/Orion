using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Orion
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapMvcAttributeRoutes(); //enables attributes
            //Creating custom route, the order of routs matter from most specific to most generic
            //routes.MapRoute(
            //    "BooksByReleaseDate",
            //    "movies/released/{year}/{month}",
            //    new { controller = "Books", action = "ByReleaseDate"}, new {year = @"\d{4}", month = @"\d{2}" });
            //default route
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
