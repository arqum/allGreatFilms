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
    public class MovieAddController : Controller
    {
        
         // to load the lists in the form
        private MovieAccess _movieAccess = new MovieAccess();
        private LanguageAccess _languageAccess = new LanguageAccess();
        private WriterAccess _writerAccess = new WriterAccess();
        private DirectorAccess _directorAccess = new DirectorAccess();
        private CountryAccess _countryAccess = new CountryAccess();


        // GET: Common/MovieAdd
        public ActionResult Index()
        {
            return View();
        }

        // GET: Common/MovieAdd/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [AllowAnonymous]
        // GET: Common/MovieAdd/Create
        public ActionResult Create()
        {

            ViewBag.writer = new SelectList(_writerAccess.GetALL().ToList(), "writer_id", "name");
            ViewBag.country = new SelectList(_countryAccess.GetALL().ToList(), "country_id", "name");
            ViewBag.director = new SelectList(_directorAccess.GetALL().ToList(), "director_id", "name");
            ViewBag.language = new SelectList(_languageAccess.GetALL().ToList(), "lang_id", "name");

            return View();
        }

        // POST: Common/MovieAdd/Create
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Create(movie movie)
        {
            try
            {



                movie.dateAdded = DateTime.Now; 
                _movieAccess.AddMovie(movie);


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Common/MovieAdd/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Common/MovieAdd/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Common/MovieAdd/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Common/MovieAdd/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
