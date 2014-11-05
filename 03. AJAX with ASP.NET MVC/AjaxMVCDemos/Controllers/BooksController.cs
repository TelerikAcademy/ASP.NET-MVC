namespace AjaxMVCDemos.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    using AjaxMVCDemos.Models;

    public class BooksController : Controller
    {
        public ActionResult Index()
        {
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

        public ActionResult ContentById(int id)
        {
            if (!Request.IsAjaxRequest())
            {
                Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return this.Content("This action can be invoke only by AJAX call");
            }

            var book = BooksData.GetAll().FirstOrDefault(x => x.Id == id);
            if (book == null)
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return this.Content("Book not found");
            }

            return this.Content(book.Content);
        }

        public ActionResult All()
        {
            return this.View();
        }

        public JsonResult AllBooks()
        {
            var books = BooksData.GetAll()
                .AsQueryable().Select(TitledBookViewModel.FromBook);

            return this.Json(books, JsonRequestBehavior.AllowGet);
        }
    }
}