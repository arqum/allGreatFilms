using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AllGreatFilms.BusinessLayer;
using AllGreatFilms.BusinessObjectLayer;

namespace AllGreatMovies.Client.Areas.Security.Controllers
{
    public class RegisterController : Controller
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
                    userAccess.AddUser(user);
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    return RedirectToAction("Login", "Login");
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