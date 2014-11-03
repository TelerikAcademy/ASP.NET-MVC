namespace AjaxMVCDemos.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AjaxMVCDemos.Data;
    using AjaxMVCDemos.ViewModels;

    public class BooksController : Controller
    {
        public ActionResult Index(int? id)
        {
            if (id != null && Request.IsAjaxRequest())
            {
                var bookContent = BooksData
                    .GetAll()
                    .FirstOrDefault(x => x.Id == id)
                    .Content;

                return this.Content(bookContent);
            }

            var data = BooksData
                .GetAll()
                .AsQueryable()
                .Select(BookViewModel.FromBook)
                .ToList();

            return this.View(data);
        }

        public ActionResult Search(string query)
        {
            var result = BooksData
                .GetAll()
                .AsQueryable()
                .Where(book => book.Title.ToLower().Contains(query.ToLower()))
                .Select(BookViewModel.FromBook)
                .ToList();

            return this.PartialView("_BookResult", result);
        }

        public ActionResult All()
        {
            return this.View();
        }

        public JsonResult AllBooks()
        {
            var books = BooksData.GetAll();

            return this.Json(books, JsonRequestBehavior.AllowGet);
        }
    }
}