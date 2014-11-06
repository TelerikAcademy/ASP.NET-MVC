namespace Caching.MVC.Controllers
{
    using System;
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        // [OutputCache(Duration = 10, VaryByParam = "none")]
        // [OutputCache(Duration = 10, VaryByParam = "none", Location = OutputCacheLocation.Server)]
        // [OutputCache(Duration = 15, VaryByParam = "id")]
        // [OutputCache(Duration = 20, VaryByCustom = "Browser", VaryByParam = "none")]
        // [OutputCache(CacheProfile = "LongLived")]
        public ActionResult Index(int? id)
        {
            this.ViewBag.Id = id;
            this.ViewBag.Time = DateTime.Now;
            return this.View();
        }

        public ActionResult NotCachedPage()
        {
            return this.View();
        }

        public ActionResult PageFragmentCaching()
        {
            return this.View();
        }

        [OutputCache(Duration = 10, VaryByParam = "none")]
        [ChildActionOnly]
        public ActionResult ChildAction()
        {
            return this.PartialView();
        }
    }
}
