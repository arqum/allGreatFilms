//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using AllGreatFilms.BusinessLayer;
//using AllGreatFilms.BusinessLayer.ViewModels;
//using AllGreatFilms.DataAcessLayer.Model;

//namespace AllGreatMovies.Client.Controllers   
//{
    
    
//    public class UserController : Controller
//    {
        
//        // GET: User
//        public ActionResult Index()
//        {


//            return View();
//        }

//        [HttpPost]
//        public ActionResult Register(AllGreatFilms.DataAcessLayer.Model.user user)
//        {
//            if (ModelState.IsValid)
//            {
               
//                else
//                {
//                    //if not already in the db, add the user, shelves, and profile
//                    db.Users.Add(NewUser);
//                    db.User_profiles.Add(NewProfile);
//                    db.User_shelves.Add(NewShelf);

//                    try
//                    {
//                        db.SaveChanges();
//                    }
//                    catch (DbEntityValidationException ex)
//                    {
//                        foreach (var entityValidationErrors in ex.EntityValidationErrors)
//                        {
//                            foreach (var validationError in entityValidationErrors.ValidationErrors)
//                            {
//                                Response.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
//                            }
//                        }
//                    }




//                }
//            }
//            return View();
//        }
//    }
//}