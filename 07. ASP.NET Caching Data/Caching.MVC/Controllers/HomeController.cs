namespace Caching.MVC.Controllers
{
    using System;
    using System.Web.Mvc;
    using System.Web.UI;

    public class HomeController : Controller
    {
        // [OutputCache(Duration = 10, VaryByParam = "none")]
        // [OutputCache(Duration = 10, VaryByParam = "none", Location = OutputCacheLocation.Server)]
        // [OutputCache(Duration = 15, VaryByParam = "id")]
        // [OutputCache(Duration = 20, VaryByCustom = "Browser", VaryByParam = "none")]
        // [OutputCache(CacheProfile = "LongLived")]
        public ActionResult Index(int? id)
        {
            ViewBag.Id = id;
            ViewBag.Time = DateTime.Now;
            return this.View();
        }

        public ActionResult NotCachedPage()
        {
            return this.View();
        }
    }
}
