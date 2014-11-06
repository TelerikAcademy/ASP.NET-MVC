namespace Caching.MVC.Controllers
{
    using System;
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        public ActionResult Index(int id)
        {
            ViewBag.Id = id;
            ViewBag.Time = DateTime.Now;
            return this.View();
        }
    }
}