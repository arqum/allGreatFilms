using AllGreatFilms.BusinessLayer;
using AllGreatFilms.BusinessLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ALLGREATFILMS.CLIENT.LOCAL.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCards()
        {
            MovieAccess ma = new MovieAccess();

            List<homeList_vm> cards = new List<homeList_vm>();
            cards = ma.GetHomeList();
            return PartialView("MovieCards", cards);
        }
    }
}