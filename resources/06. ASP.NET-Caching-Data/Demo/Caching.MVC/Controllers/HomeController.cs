namespace Caching.MVC.Controllers
{
    using System;
    using System.Globalization;
    using System.Web.Caching;
    using System.Web.Mvc;
    using System.Web.UI;

    public class HomeController : Controller
    {
        [OutputCache(Duration = 30)]
        public ActionResult Index(int? id)
        {
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
        public ActionResult CachedDate()
        {
            return this.PartialView("ChildAction");
        }

        public ActionResult DataCaching()
        {
            if (this.HttpContext.Cache["time"] == null)
            {

                // this.Cache["time"] = DateTime.Now;
                this.HttpContext.Cache.Insert(
                    "listOfItems",                           // key
                    DateTime.Now,                     // value
                    null,                             // dependencies
                    DateTime.Now.AddSeconds(10),      // absolute exp.
                    TimeSpan.Zero,                    // sliding exp.
                    CacheItemPriority.Low,        // priority
                    new CacheItemRemovedCallback(this.OnCacheItemRemovedCallback)); // callback delegate
            }

            this.ViewBag.CurrentTimeSpan = ((DateTime)this.HttpContext.Cache["time"]).ToString(CultureInfo.InvariantCulture);

            return this.View();
        }

        private void OnCacheItemRemovedCallback(string key, object value, CacheItemRemovedReason reason)
        {
            System.IO.File.WriteAllText(Server.MapPath("/mytext.txt"), key);
        }
    }
}
