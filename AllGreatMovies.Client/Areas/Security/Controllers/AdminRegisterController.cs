using AllGreatFilms.BusinessLayer;
using AllGreatFilms.BusinessObjectLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AllGreatMovies.Client.Areas.Security.Controllers
{
    public class AdminRegisterController : Controller
    {
        // GET: Security/Register
        [AllowAnonymous]
        public ActionResult Register()
        {


            return View();
        }


        //Register the user here
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Register(user user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserAccess userAccess = new UserAccess();
                    userAccess.AddAdmin(user);
                    return View();
                }
                else
                {
                    return View("Index");
                }
            }
            catch (Exception e1)
            {
                TempData["Msg"] = "Create Failed : " + e1.Message;
                return RedirectToAction("Index");
            }




        }
    }
}