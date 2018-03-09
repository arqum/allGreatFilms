using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AllGreatMovies.Client
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
    
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "HomeList", action = "HomeList", id = UrlParameter.Optional}

            );

            (RouteTable.Routes[routes.Count - 1] as Route).DataTokens["area"] = "Common";
        }
    }
}
