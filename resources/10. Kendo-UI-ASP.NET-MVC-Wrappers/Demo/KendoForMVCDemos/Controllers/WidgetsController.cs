using KendoForMVCDemos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KendoForMVCDemos.ViewModels;
using Kendo.Mvc.UI;
using System.IO;

namespace KendoForMVCDemos.Controllers
{
    public class WidgetsController : Controller
    {
        public WidgetsController()
        {
            this.Data = new ApplicationDbContext();
        }

        public ApplicationDbContext Data { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Calendar()
        {
            return View();
        }

        public ActionResult AutoComplete()
        {
            var books = this.Data.Books.Select(ShortBookViewModel.FromBook);

            return View(books);
        }

        public JsonResult GetAutocompleteData(string text)
        {
            var selectedBooks = this.Data.Books
                .Where(x => x.Title.ToLower().Contains(text.ToLower()))
                .Select(ShortBookViewModel.FromBook);

            return Json(selectedBooks, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Saykor(string serversideautocomplete)
        {
            return null;
        }

        public ActionResult DropDownList()
        {
            var categories = this.Data
                .Categories
                .Select(CategoryViewModel.FromCategory);

            return View(categories);
        }

        public JsonResult GetCascadingBooks(int categoryId)
        {
            var selectedBooks = this.Data
                .Books
                .Where(x => x.CategoryId == categoryId)
                .Select(ShortBookViewModel.FromBook).ToList();

            return Json(selectedBooks, JsonRequestBehavior.AllowGet);
        }

        public ActionResult TreeView()
        {
            var result = this.Data.Categories.Include("Books").ToList().Select(x => new TreeViewItemModel
                {
                    Text = x.Name,
                    Items = x.Books.Select(y => new TreeViewItemModel
                        {
                            Text = y.Title
                        })
                        .ToList()
                });

            return View(result);
        }

        public ActionResult Upload()
        {
            return View();
        }

        public ActionResult UploadedFiles(IEnumerable<HttpPostedFileBase> upload)
        {
            if (upload != null)
            {
                foreach (var file in upload)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var physicalPath = Path.Combine(Server.MapPath("~/App_Data"), fileName);

                    file.SaveAs(physicalPath);
                }
            }

            return Content("");
        }
	}
}