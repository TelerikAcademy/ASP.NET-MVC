namespace AjaxMVCDemos.Controllers
{
    using System;
    using System.Threading;
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult RawAjax()
        {
            return this.View();
        }

        public ActionResult ServerTime()
        {
            var isAjax = Request.IsAjaxRequest();
            Thread.Sleep(2000);
            return this.Content(isAjax + " " + DateTime.Now.ToLongTimeString());
        }

        public ActionResult JQueryAjax()
        {
            return this.View();
        }

        public ActionResult UnobtrusiveAjax()
        {
            return this.View();
        }

        public ActionResult AjaxActionLink()
        {
            return this.View();
        }
    }
}
