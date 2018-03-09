using AllGreatFilms.BusinessLayer;
using AllGreatFilms.BusinessObjectLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AllGreatMovies.Client.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class ActorController : Controller
    {
        private CountryAccess _countryAccess = new CountryAccess();
        private ActorAccess _actorAccess = new ActorAccess();

        public ActionResult Create()
        {

            ViewBag.country_id = new SelectList(_countryAccess.GetALL().ToList(), "country_id", "name");

            //MembershipUser CurrentUser = Membership.GetUser(User.Identity.Name);
            //Response.Write("CurrentUser ID :: " + CurrentUser.ProviderUserKey);



            return View();
        }

        [HttpPost]
        public ActionResult Create(actor actor)
        {
            try
            {

                _actorAccess.AddActor(actor);


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}