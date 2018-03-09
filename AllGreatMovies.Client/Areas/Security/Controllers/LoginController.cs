using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AllGreatFilms.BusinessObjectLayer;
using AllGreatFilms.BusinessLayer;
using System.Web.Security;

namespace AllGreatMovies.Client.Areas.Security
{
    public class LoginController : Controller
    {
        // GET: Security/Login
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(user user)
        {
            try
            {
                if (Membership.ValidateUser(user.email, user.password))
                {
                    FormsAuthentication.SetAuthCookie(user.email,false);
                   // FormsAuthentication.SetAuthCookie(user.email, false);
                    

                    //checking 


                    return RedirectToAction("HomeList", "HomeList", new { area = "Users" });
                }
                else
                {
                    TempData["Msg"] = "Login Failed  ";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception E1)
            {
                TempData["Msg"] = "Login Failed  " + E1.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult LoginAjax(string email, string password)
        {
            try
            {
                if (Membership.ValidateUser(email,password))
                {
                    FormsAuthentication.SetAuthCookie(email, false);
                    // FormsAuthentication.SetAuthCookie(user.email, false);


                    //checking 


                    return RedirectToAction("HomeList", "HomeList", new { area = "Users" });
                }
                else
                {
                    TempData["Msg"] = "Login Failed  ";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception E1)
            {
                TempData["Msg"] = "Login Failed  " + E1.Message;
                return RedirectToAction("Index");
            }
        }


        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("HomeList", "HomeList", new { area = "Common" });
        }
    }

   
}