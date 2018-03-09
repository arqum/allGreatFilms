using AllGreatFilms.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AllGreatMovies.Client.Areas.Users.Controllers
{
     [AllowAnonymous]
    public class RandomController : Controller
    {
        // GET: Common/Random

        public ActionResult Random()
        {

            AgfMembershipProvider membership = new AgfMembershipProvider();
            MovieAccess movieAccess = new MovieAccess();
            bool check;
            if (check = System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {

                var user = User.Identity.Name.ToString();
                Guid? userId = membership.GetUserIdByEmail(user);
                var res = movieAccess.GetRandom(userId).OrderBy(r => Guid.NewGuid()).Take(1);
                return View(res);


            }

            else
            {

                var res = movieAccess.GetRandom().OrderBy(r => Guid.NewGuid()).Take(1);
                return View(res);

            }
        }

        [AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        public PartialViewResult _RandomMovie()
        {
           
            AgfMembershipProvider membership = new AgfMembershipProvider();
            MovieAccess movieAccess = new MovieAccess();
            bool check;
            if (check = System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {

                var user = User.Identity.Name.ToString();
                Guid? userId = membership.GetUserIdByEmail(user);
                var res = movieAccess.GetRandom(userId).OrderBy(r => Guid.NewGuid()).Take(1);
            return PartialView("_RandomMovie", res);

            }

            else
            {

                var res = movieAccess.GetRandom().OrderBy(r => Guid.NewGuid()).Take(1);
                return PartialView("_RandomMovie", res);

            }
        }
    }
}