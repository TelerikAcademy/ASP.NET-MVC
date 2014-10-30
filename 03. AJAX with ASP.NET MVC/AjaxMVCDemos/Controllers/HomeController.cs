using AjaxMVCDemos.Data;
using AjaxMVCDemos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AjaxMVCDemos.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            var book = BooksData.GetBook();

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

            var content = BooksData.GetBook().Content;

            return Content(content);
        } 

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}