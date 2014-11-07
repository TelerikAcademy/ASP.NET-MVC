using KendoForMVCDemos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KendoForMVCDemos.Areas.Administration.ViewModels;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace KendoForMVCDemos.Areas.Administration.Controllers
{
    [Authorize(Roles="Admin")]
    public class BooksController : Controller
    {
        public BooksController()
        {
            this.Data = new ApplicationDbContext();
        }

        public ApplicationDbContext Data { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult CreateBook([DataSourceRequest] DataSourceRequest request, DetailedBookViewModel book)
        {
            if (book != null && ModelState.IsValid)
            {
                var category = this.Data.Categories.FirstOrDefault(x => x.Name == book.CategoryName);

                var newBook = new Book
                    {
                        Title = book.Title,
                        Content = book.Content,
                        Author = book.Author,
                        Category = category,
                    };

                this.Data.Books.Add(newBook);
                this.Data.SaveChanges();

                book.Id = newBook.Id;
            }

            return Json(new[] { book }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ReadBooks([DataSourceRequest]DataSourceRequest request)
        {
            var result = this.Data.Books.Include("Categories").Select(DetailedBookViewModel.FromBook);

            return Json(result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateBook([DataSourceRequest] DataSourceRequest request, DetailedBookViewModel book)
        {
            var existingBook = this.Data.Books.FirstOrDefault(x => x.Id == book.Id);

            if (book != null && ModelState.IsValid)
            {
                existingBook.Title = book.Title;
                existingBook.Content = book.Content;
                existingBook.Author = book.Author;
                existingBook.Category = this.Data.Categories.FirstOrDefault(x => x.Name == book.CategoryName);

                this.Data.SaveChanges();
            }

            return Json((new[] { book }.ToDataSourceResult(request, ModelState)), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteBook([DataSourceRequest] DataSourceRequest request, DetailedBookViewModel book)
        {
            var existingBook = this.Data.Books.FirstOrDefault(x => x.Id == book.Id);

            this.Data.Books.Remove(existingBook);
            this.Data.SaveChanges();

            return Json(new[] { book }, JsonRequestBehavior.AllowGet);
        }
	}
}