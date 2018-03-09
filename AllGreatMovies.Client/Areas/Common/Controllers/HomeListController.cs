using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AllGreatFilms.BusinessObjectLayer;
using AllGreatFilms.BusinessLayer;
using AllGreatFilms.BusinessLayer.ViewModels;

namespace AllGreatMovies.Client.Areas.Common.Controllers
{
    [AllowAnonymous]
    public class HomeListController : Controller
    {
        private homeList_vm vm = new homeList_vm();
        // GET: Common/HomeList
        public ActionResult HomeList()
        {
            MovieAccess movieAccess = new MovieAccess();
           
                var user = User.Identity.Name.ToString();
                var res = movieAccess.GetHomeList().OrderBy(s => s.DateAdded);
                return View(res);
            

        }


        [AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        public PartialViewResult HomeList_byLatest()
        {

            MovieAccess movieAccess = new MovieAccess();
           
                var res = movieAccess.GetHomeList().OrderBy(s => s.DateAdded);
                var count = Math.Ceiling(res.Count() / 6.0);
                ViewBag.Pages = count;
                return PartialView("_GetCardss", res);
         }     

        



        [AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        public PartialViewResult HomeList_byRating()
        {

            AgfMembershipProvider membership = new AgfMembershipProvider();
            MovieAccess movieAccess = new MovieAccess();
            bool check;
            if (check = System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {

                var user = User.Identity.Name.ToString();
                Guid? userId = membership.GetUserIdByEmail(user);
                //var res = movieAccess.GetHomeList(userId).OrderByDescending(r => r.GreatnessRating);

                var res = movieAccess.GetHomeList(userId).OrderByDescending(s => s.GreatnessRating);

                // return View(res);
                return PartialView("_GetCardss", res);
            }

            else
            {


                var res = movieAccess.GetHomeList().OrderByDescending(s => s.GreatnessRating);
                return PartialView("_GetCardss", res);

            }

        }



        [AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        public PartialViewResult HomeList_byMood()
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
        public PartialViewResult HomeList_byGenre()
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