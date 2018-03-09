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
    public class WriterController : Controller
    {

        private WriterAccess _writerAccess = new WriterAccess();

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(writer writer)
        {
            try
            {

                _writerAccess.AddWriter(writer);


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}