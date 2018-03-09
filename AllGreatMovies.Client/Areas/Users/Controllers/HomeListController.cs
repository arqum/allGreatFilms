using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AllGreatFilms.BusinessObjectLayer;
using AllGreatFilms.BusinessLayer;
using AllGreatFilms.BusinessLayer.ViewModels;

namespace AllGreatMovies.Client.Areas.Users.Controllers
{
    [Authorize(Roles = "user")]
    public class HomeListController : Controller
    {
     

        public ActionResult HomeList(string Page)
        {
            AgfMembershipProvider membership = new AgfMembershipProvider();
            MovieAccess movieAccess = new MovieAccess();
            bool check;
            if (check = System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {

                var user = User.Identity.Name.ToString();
                Guid? userId = membership.GetUserIdByEmail(user);
                var res = movieAccess.GetHomeList(userId).OrderBy(s => s.DateAdded);
                var count = Math.Ceiling(res.Count() / 6.0);
                ViewBag.Pages = count;

                int page = int.Parse(Page == null ? "1" : Page);
                ViewBag.Page = page;


                res = res.Skip((page - 1) * 6).ToList().Take(6).OrderBy(s => s.DateAdded);
                return View(res);
            }

            else
            {

                var res = movieAccess.GetHomeList().OrderBy(s => s.DateAdded);
                var count = Math.Ceiling(res.Count() / 6.0);
                ViewBag.Pages = count;

                int page = int.Parse(Page == null ? "1" : Page);
                ViewBag.Page = page;


                res = res.Skip((page - 1) * 6).ToList().Take(6).OrderBy(s => s.DateAdded);
                return View(res);

            }

        }


        [AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        public PartialViewResult HomeList_byLatest(string Page)
        {

            AgfMembershipProvider membership = new AgfMembershipProvider();
            MovieAccess movieAccess = new MovieAccess();
            bool check;
            if (check = System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {

                var user = User.Identity.Name.ToString();
                Guid? userId = membership.GetUserIdByEmail(user);
                var res = movieAccess.GetHomeList(userId).OrderBy(s => s.DateAdded);
                var count = Math.Ceiling(res.Count() / 6.0);
                ViewBag.Pages = count;

                int page = int.Parse(Page == "0"  ? "1" : Page);
                ViewBag.Page = page;


                res = res.Skip((page - 1) * 6).ToList().Take(6).OrderBy(s => s.DateAdded);

                return PartialView("_GetCardss", res);

            }

            else
            {

                var res = movieAccess.GetHomeList().OrderBy(s => s.DateAdded);
                var count = Math.Ceiling(res.Count() / 6.0);
                ViewBag.Pages = count;

                int page = int.Parse(Page == null ? "1" : Page);
                ViewBag.Page = page;


                res = res.Skip((page - 1) * 6).ToList().Take(6).OrderBy(s => s.DateAdded);
                return PartialView("_GetCardss", res);

            }

        }


        [AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        public PartialViewResult HomeList_byLatest2(string Page)
        {

            AgfMembershipProvider membership = new AgfMembershipProvider();
            MovieAccess movieAccess = new MovieAccess();
            bool check;
            if (check = System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {

                var user = User.Identity.Name.ToString();
                Guid? userId = membership.GetUserIdByEmail(user);
                var res = movieAccess.GetHomeList(userId).OrderBy(s => s.DateAdded);
                var count = Math.Ceiling(res.Count() / 6.0);
                ViewBag.Pages = count;

                int page = int.Parse(Page == null ? "1" : Page);
                ViewBag.Page = page;


                res = res.Skip((page - 1) * 6).ToList().Take(6).OrderBy(s => s.DateAdded);

                return PartialView("_GetCardss", res);
            }

            else
            {

                var res = movieAccess.GetHomeList().OrderBy(s => s.DateAdded);
                return PartialView("_GetCardss", res);

            }

        }



        [AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        public PartialViewResult HomeList_byRating(string Page)
        {

            AgfMembershipProvider membership = new AgfMembershipProvider();
            MovieAccess movieAccess = new MovieAccess();
            bool check;
            if (check = System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {

                var user = User.Identity.Name.ToString();
                Guid? userId = membership.GetUserIdByEmail(user);
                var res = movieAccess.GetHomeList(userId).OrderByDescending(s => s.GreatnessRating);
                var count = Math.Ceiling(res.Count() / 6.0);
                ViewBag.Pages = count;

                int page = int.Parse(Page == "0" ? "1" : Page);
                ViewBag.Page = page;

                res = res.Skip((page - 1) * 6).ToList().Take(6).OrderByDescending(s => s.GreatnessRating);


               // return View(res);
                return PartialView("_GetCardss", res);
            }

            else
            {

                var res = movieAccess.GetHomeList().OrderByDescending(s => s.GreatnessRating);
                var count = Math.Ceiling(res.Count() / 6.0);
                ViewBag.Pages = count;

                int page = int.Parse(Page == "0" ? "1" : Page);
                ViewBag.Page = page;

                res = res.Skip((page - 1) * 6).ToList().Take(6).OrderByDescending(s => s.GreatnessRating);


                // return View(res);
                return PartialView("_GetCardss", res); 


            }

        }



        [AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        public PartialViewResult HomeList_byMood(string Page)
        {

            MoodsAccess MoodsAccess = new MoodsAccess();
            var res = MoodsAccess.GetALL();


            return PartialView("_Moods", res);

            //Json(new { MoodsList = res }, JsonRequestBehavior.AllowGet);

        }


        [HttpPost]
        [AllowAnonymous]
        public ActionResult HomeList_byMood(List<int> moods)
        {

            AgfMembershipProvider membership = new AgfMembershipProvider();
            MovieAccess movieAccess = new MovieAccess();
            bool check;
            if (check = System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {

                var user = User.Identity.Name.ToString();
                Guid? userId = membership.GetUserIdByEmail(user);
                var res = movieAccess.GetHomeListForUserSelectedMoods(moods, userId);
                return PartialView("_GetCardss", res);


            }
            else
            {


                var res = movieAccess.GetHomeListForUserSelectedMoods(moods);
                return PartialView("_GetCardss", res);

            }



        }



        [AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        public PartialViewResult HomeList_byGenre(string Page)
        {
            GenresAccess GenreAccess = new GenresAccess();
            var res = GenreAccess.GetALL();


            return PartialView("_Genres", res);

        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult HomeList_bySelectedGenre(List<int> genres)
        {

            AgfMembershipProvider membership = new AgfMembershipProvider();
            MovieAccess movieAccess = new MovieAccess();
            bool check;
            if (check = System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {

                var user = User.Identity.Name.ToString();
                Guid? userId = membership.GetUserIdByEmail(user);
                var res = movieAccess.GetHomeListForUserSelectedGenres(genres, userId);
                return PartialView("_GetCardss", res);


            }
            else
            {


                var res = movieAccess.GetHomeListForUserSelectedGenres(genres);
                return PartialView("_GetCardss", res);

            }



        }


    }
}