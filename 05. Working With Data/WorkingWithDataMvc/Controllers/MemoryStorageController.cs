namespace WorkingWithDataMvc.Controllers
{
    using System;
    using System.Web.Mvc;

    public class MemoryStorageController : Controller
    {
        public ActionResult Index()
        {
            var now = DateTime.Now;
            if (this.HttpContext.Session["date"] == null)
            {
                this.HttpContext.Session["date"] = now;
            }

            var date = (DateTime)this.HttpContext.Session["date"];

            return View(date);
        }

        public ActionResult SaveToTempData()
        {
            this.TempData["message"] = "TempData success!";
            return RedirectToAction("Redirection");
        }

        public ActionResult Redirection()
        {
            var data = this.TempData["message"];
            return View(data);
        }

        public ActionResult SaveToCache()
        {
            this.HttpContext.Cache["message"] = "Cache success!";
            return RedirectToAction("RedirectForCache");
        }

        public ActionResult RedirectForCache()
        {
            var data = this.HttpContext.Cache["message"];
            return View(data);
        }
    }
}