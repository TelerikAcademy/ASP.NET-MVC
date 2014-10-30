using System;
using System.Web.Mvc;

namespace CSRF_Example.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
        [ActionName("XSS-MVC")]
        public ActionResult XSSMvc()
        {
            return View("XSS-MVC");
        }
    }
}
