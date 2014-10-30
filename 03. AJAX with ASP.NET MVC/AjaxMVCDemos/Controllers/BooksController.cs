using AjaxMVCDemos.Data;
using AjaxMVCDemos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AjaxMVCDemos.Controllers
{
    public class BooksController : Controller
    {
        public ActionResult Index(int? id)
        {
            if (id != null && Request.IsAjaxRequest())
            {
                var bookContent = BooksData
                    .GetAllBooks()
                    .FirstOrDefault(x => x.Id == id)
                    .Content;

                return Content(bookContent);
            }

            var data = BooksData
                .GetAllBooks()
                .AsQueryable()
                .Select(BookViewModel.FromBook)
                .ToList();

            return View(data);
        }

        public ActionResult Search(string query)
        {
            var result = BooksData
                .GetAllBooks()
                .AsQueryable()
                .Where(book => book.Title.ToLower().Contains(query.ToLower()))
                .Select(BookViewModel.FromBook)
                .ToList();

            return PartialView("_BookResult", result);
        }

        public ActionResult All()
        {
            return View();
        }

        public JsonResult AllBooks()
        {
            var books = BooksData.GetAllBooks();

            return Json(books, JsonRequestBehavior.AllowGet);
        }
	}
}