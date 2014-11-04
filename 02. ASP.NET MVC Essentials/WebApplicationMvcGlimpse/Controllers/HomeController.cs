using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplicationMvcGlimpse.Controllers
{
    public class HomeController : Controller
    {
        [OutputCache(Duration=10)]
        public ActionResult CurrentDateTime()
        {
            return Content(DateTime.Now.ToString());
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ReturnJSON()
        {
            return this.Json(DateTime.Now, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ReturnJS()
        {
            return this.JavaScript("var a = 1;");
        }

        public ActionResult ReturnFile()
        {
            return new HttpUnauthorizedResult();

            return this.File(@"C:\Temp\test.txt", "application/pdf", "file.pdf");
        }
    }
}