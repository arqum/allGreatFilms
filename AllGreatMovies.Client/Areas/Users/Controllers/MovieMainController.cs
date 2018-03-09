using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AllGreatFilms.BusinessLayer.ViewModels;
using AllGreatFilms.BusinessLayer;


namespace AllGreatMovies.Client.Areas.Users.Controllers
{
    public class MovieMainController : Controller
    {
        private movie_main_vm vm = new movie_main_vm();

        // GET: Users/MovieMain
        [AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        public ActionResult MovieMain(int id)
        {


            AgfMembershipProvider membership = new AgfMembershipProvider();
            MovieAccess movieAccess = new MovieAccess();
            bool check;
            if (check = System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {

                var user = User.Identity.Name.ToString();
                Guid? userId = membership.GetUserIdByEmail(user);

                var res = movieAccess.GetMovieDetails(id, userId);

               // return View(res);
                return View(res);
            }

            else
            {

                 var res = movieAccess.GetHomeList().OrderByDescending(s => s.GreatnessRating);
                return PartialView(res);

            }
            
        }
    }
}

