using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AllGreatFilms.BusinessObjectLayer;
using AllGreatFilms.BusinessLayer;
using System.Web.Security;
using System.Text;
using System.Security.Cryptography;

namespace AllGreatFilms.Client.Areas.Security
{
    public class LoginController : BaseSecurityController
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
                    FormsAuthentication.SetAuthCookie(user.email, false);
                    return RedirectToAction("Index", "Home", new { area = "Common" });
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
            return RedirectToAction("Index", "Home", new { area = "Common" });
        }


    }
}