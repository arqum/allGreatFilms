using AllGreatFilms.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AllGreatMovies.Client.Areas.Users.Controllers
{
    public class UserProfileController : Controller
    {
        // GET: Users/UserProfile
        public ActionResult UserProfile()
        {
            AgfMembershipProvider membership = new AgfMembershipProvider();
            MovieAccess movieAccess = new MovieAccess();
            bool check;
            if (check = System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {

                var user = User.Identity.Name.ToString();
                Guid? userId = membership.GetUserIdByEmail(user);
                var res = movieAccess.GetUserToWatchMovies(userId).OrderByDescending(s => s.DateAdded);
                var resWatched = movieAccess.GetUserWatchedMovies(userId).OrderByDescending(s => s.DateAdded);
                var resFav = movieAccess.GetUserFavMovies(userId).OrderByDescending(s => s.DateAdded);


                var Tcount = res.Count();
                var Wcount = resWatched.Count();
                var Fcount = resFav.Count();


                ViewBag.count = Tcount;
                ViewBag.Wcount = Wcount;
                ViewBag.Fcount = Fcount;



                ViewBag.ListTitle = "To-Watch";

                return View(res);
            }

            else
            {

                var res = movieAccess.GetHomeList().OrderByDescending(s => s.DateAdded);
                return View(res);

            }
        }



        public PartialViewResult _UserProfile()
        {
            AgfMembershipProvider membership = new AgfMembershipProvider();
            MovieAccess movieAccess = new MovieAccess();
            bool check;
            if (check = System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {

                var user = User.Identity.Name.ToString();
                Guid? userId = membership.GetUserIdByEmail(user);
                var res = movieAccess.GetUserToWatchMovies(userId).OrderByDescending(s => s.DateAdded);
                ViewBag.ListTitle = "To-Watch";
                var Tcount = res.Count();
                ViewBag.count = Tcount;
                return PartialView("_UserListContainer", res);
            }

            else
            {

                var res = movieAccess.GetHomeList().OrderByDescending(s => s.DateAdded);
                return PartialView("_UserListContainer", res);

            }
        }





        public PartialViewResult _Watched()
        {
            AgfMembershipProvider membership = new AgfMembershipProvider();
            MovieAccess movieAccess = new MovieAccess();
            bool check;
            if (check = System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {

                var user = User.Identity.Name.ToString();
                Guid? userId = membership.GetUserIdByEmail(user);
                var res = movieAccess.GetUserWatchedMovies(userId).OrderByDescending(s => s.DateAdded);
                ViewBag.ListTitle = "Watched";
                var Tcount = res.Count();
                ViewBag.Wcount = Tcount;
                return PartialView("_UserListContainer", res);
            }

            else
            {

                var res = movieAccess.GetHomeList().OrderByDescending(s => s.DateAdded);
                return PartialView("_UserListContainer", res);

            }
        }

        public PartialViewResult _fav()
        {
            AgfMembershipProvider membership = new AgfMembershipProvider();
            MovieAccess movieAccess = new MovieAccess();
            bool check;
            if (check = System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {

                var user = User.Identity.Name.ToString();
                Guid? userId = membership.GetUserIdByEmail(user);
                var res = movieAccess.GetUserFavMovies(userId).OrderByDescending(s => s.DateAdded);
                ViewBag.ListTitle = "Favorite";
                var Tcount = res.Count();
                ViewBag.Fcount = Tcount;
                return PartialView("_UserListContainer", res);
            }

            else
            {

                var res = movieAccess.GetHomeList().OrderByDescending(s => s.DateAdded);
                return PartialView("_UserListContainer", res);

            }
        }


      
    }
}
