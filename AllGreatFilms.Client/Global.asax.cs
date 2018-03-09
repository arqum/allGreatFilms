using AllGreatFilms.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AllGreatFilms.Client
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            AllGreatFilms.Client.RouteConfig.RegisterRoutes(RouteTable.Routes);          
            GlobalFilters.Filters.Add(new AuthorizeAttribute());
        }
    }
}
