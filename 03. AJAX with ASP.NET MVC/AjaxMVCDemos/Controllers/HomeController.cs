namespace AjaxMVCDemos.Controllers
{
    using System;
    using System.Threading;
    using System.Web.Mvc;

    using AjaxMVCDemos.Data;
    using AjaxMVCDemos.ViewModels;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var book = BooksData.Get();

            var model = new BookViewModel
            {
                Id = book.Id,
                Title = book.Title,
                Content = book.Content
            };

            return this.View(model);
        }

        public JsonResult GetData()
        {
            var data = new BookViewModel
                {
                    Content = "Bla",
                    Title = "Bla 2 "
                };

            return this.Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetFullBookContent()
        {
            System.Threading.Thread.Sleep(2000);

            var content = BooksData.Get().Content;

            return this.Content(content);
        }

        public ActionResult RawAjax()
        {
            return this.View();
        }

        public ActionResult ServerTime()
        {
            Thread.Sleep(2000);
            return this.Content(DateTime.Now.ToLongTimeString());
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