namespace Caching.MVC.Controllers
{
    using System;
    using System.Globalization;
    using System.Web.Caching;
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

        public ActionResult DataCaching()
        {
            // this.Cache.Remove("time");
            if (this.HttpContext.Cache["time"] == null)
            {
                // this.Cache["time"] = DateTime.Now;
                this.HttpContext.Cache.Insert(
                    "time",                           // key
                    DateTime.Now,                     // value
                    null,                             // dependencies
                    DateTime.Now.AddSeconds(10),      // absolute exp.
                    TimeSpan.Zero,                    // sliding exp.
                    CacheItemPriority.Default,        // priority
                    this.OnCacheItemRemovedCallback); // callback delegate
            }

            this.ViewBag.CurrentTimeSpan = ((DateTime)this.HttpContext.Cache["time"]).ToString(CultureInfo.InvariantCulture);

            return this.View();
        }

        private void OnCacheItemRemovedCallback(string key, object value, CacheItemRemovedReason reason)
        {
            // Cache item removed
        }
    }
}
