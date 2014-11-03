using AjaxMVCDemos.Data;
using AjaxMVCDemos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace AjaxMVCDemos.Controllers
{
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

            return View(model);
        }

        public JsonResult GetData()
        {
            var data = new BookViewModel
                {
                    Content = "Bla",
                    Title = "Bla 2 "
                };

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetFullBookContent()
        {
            System.Threading.Thread.Sleep(2000);

            var content = BooksData.Get().Content;

            return Content(content);
        }

        public ActionResult RawAjax()
        {
            return this.View();
        }

        public ActionResult ServerTime()
        {
            Thread.Sleep(4000);
            return this.Content(DateTime.Now.ToLongTimeString());
        }

        public ActionResult JQueryAjax()
        {
            return this.View();
        }
    }
}