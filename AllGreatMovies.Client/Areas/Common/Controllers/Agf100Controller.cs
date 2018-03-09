using AllGreatFilms.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AllGreatMovies.Client.Areas.Common.Controllers
{
    [AllowAnonymous]
    public class AGF100Controller : Controller
    {
        // GET: Users/AGF100
        public ActionResult AGF100()
        {
            AgfMembershipProvider membership = new AgfMembershipProvider();
            MovieAccess movieAccess = new MovieAccess();
            bool check;
            if (check = System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {

                var user = User.Identity.Name.ToString();
                Guid? userId = membership.GetUserIdByEmail(user);
                var res = movieAccess.GetHomeList(userId).OrderByDescending(s => s.GreatnessRating);
                return View(res);
            }

            else
            {

                var res = movieAccess.GetHomeList().OrderByDescending(s => s.GreatnessRating);
                return View(res);

            }
        }





        [AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        public PartialViewResult _AGF100()
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
                return PartialView("_AGF100", res);
            }

            else
            {


                var res = movieAccess.GetHomeList().OrderByDescending(s => s.GreatnessRating);
                return PartialView("_AGF100", res);

            }
        }
    }

      


}