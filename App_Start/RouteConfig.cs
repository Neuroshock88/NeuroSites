using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace NeuroSites
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Ajax",                                              // Route name
                "Ajax/{action}/{id}",
                defaults: new { controller = "Ajax", action = "{action}", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                "Default",                                              // Route name
                "{*permalink}",                           // URL with parameters
                new { controller = "Default", action = "Index", id = "" }  // Parameter defaults
            );
        }
    }
}
