using ALLGREATFILMS.CLIENT.LOCAL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ALLGREATFILMS.CLIENT.LOCAL.Controllers
{
    public class FileUploadController : Controller
    {
        // GET: FileUpload
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(FileUpload image)
        {

            if(image.file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(image.file.FileName);
                var path = Path.Combine(Server.MapPath("~/Assets/IMAGES"),fileName);
                image.file.SaveAs(path);
            }

            return RedirectToAction("Index");
        }
    }
}