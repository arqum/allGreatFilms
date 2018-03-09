using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AllGreatMovies.Client.Areas.Admin.Controllers
{
    public class UserListController : Controller
    {
         [Authorize(Roles = "admin")]

        // GET: Admin/UserList
        public ActionResult Index()
        {
            return View();
        }
    }
}