using AllGreatFilms.BusinessLayer;
using AllGreatFilms.BusinessObjectLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AllGreatMovies.Client.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class DirectorController : Controller
    {

        private DirectorAccess _directorAccess = new DirectorAccess();

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]       
        public ActionResult Create(director director)
        {
            try
            {

                _directorAccess.AddDirector(director);


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}