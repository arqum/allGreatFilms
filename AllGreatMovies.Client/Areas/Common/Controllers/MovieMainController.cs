using AllGreatFilms.BusinessLayer;
using AllGreatFilms.BusinessLayer.ViewModels;
using System.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AllGreatMovies.Client.Areas.Common.Controllers
{
    public class MovieMainController : Controller
    { 
        
        private movie_main_vm vm = new movie_main_vm();

        // GET: Users/MovieMain
        [AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        public ActionResult MovieMain(int id)
        {


            MovieAccess movieAccess = new MovieAccess();    
            var res = movieAccess.GetMovieDetails(id);

            // return View(res);
            return View(res);
            

          
            
        }
    }
}