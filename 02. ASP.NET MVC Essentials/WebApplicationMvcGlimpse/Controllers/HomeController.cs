using System;
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
            return Json(DateTime.Now, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ReturnJS()
        {
            return JavaScript("var a = 1;");
        }

        public ActionResult ReturnFile()
        {
            return new HttpUnauthorizedResult();
        }
    }
}