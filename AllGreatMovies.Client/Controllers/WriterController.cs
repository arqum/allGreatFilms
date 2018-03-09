using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AllGreatFilms.BusinessLayer;
using AllGreatFilms.BusinessLayer.ViewModels;
using AllGreatFilms.BusinessObjectLayer;

namespace AllGreatMovies.Client.Controllers
{
    public class WriterController : Controller
    {
       // WriterAccess w = new WriterAccess();
        
        // GET: Writer
        [AllowAnonymous]
        public ActionResult Index()
        {
            //var writerId = w.GetWriter();
            return View();
        }
    }
}