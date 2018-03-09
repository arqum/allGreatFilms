using AllGreatFilms.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AllGreatFilms.Client.Areas.Security
{
    public class BaseSecurityController : Controller
    {
        protected UserAccess UA;
        public BaseSecurityController()
        {

            UA = new UserAccess();
        }

    }
}