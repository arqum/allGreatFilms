using AllGreatFilms.BusinessLayer;
using AllGreatFilms.BusinessObjectLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AllGreatMovies.Client.Areas.Users.Controllers
{
    public class UserActionsController : Controller
    {
        [Authorize(Roles = "user")]
        // GET: Users/UserActions
        public ActionResult GetWatchList()
        {

            return View();
        }
        [HttpPost]
        public ActionResult AddToWatchList()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Actions(int movie_id, string UserAction)
        {
            UserAccess ua = new UserAccess();

            AgfMembershipProvider membership = new AgfMembershipProvider();

            try
            {

  
                if (ModelState.IsValid)
                {

                    bool check;
                    if (check = System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
                    {

                       
                        var user = User.Identity.Name.ToString();
                        Guid? userId = membership.GetUserIdByEmail(user);


                        switch (UserAction)
                        {

                            case "w":
                                {

                                    if (ua.User_AddtoWatched(movie_id, userId) == false)
                                    {
                                        return Json(new { success = false, responseText = "Cannot add to Watched." }, JsonRequestBehavior.AllowGet);

                                    }
                                    else
                                    {
                                        return Json(new { success = true, responseText = "Cannot add to Watched." }, JsonRequestBehavior.AllowGet);


                                    }


                                }
                            case "f":
                                {
                                    if (ua.User_AddToFav(movie_id, userId) == false)
                                    {
                                        return Json(new { success = false, responseText = "Cannot add to Watched." }, JsonRequestBehavior.AllowGet);

                                    }
                                    else
                                    {
                                        return Json(new { success = true, responseText = "Cannot add to Watched." }, JsonRequestBehavior.AllowGet);


                                    }

                      

                                }
                            case "t":
                                {

                                    if (ua.AddToWatchlist(movie_id, userId) == false)
                                    {
                                        return Json(new { success = false, responseText = "Cannot add to Watched." }, JsonRequestBehavior.AllowGet);
                                        
                                    }
                                    else
                                    {
                                        return Json(new { success = true, responseText = "Cannot add to Watched." }, JsonRequestBehavior.AllowGet);
                                        

                                    }

                                    


                                }
                        }

                    }

                    else
                    {
                        ViewBag.failureMessage = "<p>FAILED. Please Login.</p>";

                        return View();

                    }



                }
            }
            catch (Exception e1)
            {
                TempData["Msg"] = "Failed" + e1.Message;
                    
            }
                return View();
            
        }

        public ActionResult AddToWatched()
        {

            return View();
        }
    }
}