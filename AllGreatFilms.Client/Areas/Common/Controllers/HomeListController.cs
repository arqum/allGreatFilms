using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AllGreatFilms.BusinessObjectLayer;

namespace AllGreatMovies.Client.Areas.Common.Controllers
{
    public class HomeListController : Controller
    {       

        // GET: Common/HomeList
        public ActionResult HomeList()
        {
            return View();
        }
    }
}