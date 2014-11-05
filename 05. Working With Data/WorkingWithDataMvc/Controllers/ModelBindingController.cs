namespace WorkingWithDataMvc.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web;
    using System.Web.Mvc;
    using WorkingWithDataMvc.Models;

    public class ModelBindingController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Parameter(int first, string second, bool third)
        {
            return this.RedirectToAction(string.Format("{0} {1} {2}", first, second, third));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Object(PersonViewModel person)
        {
            return this.SetTempDataAndRedirectToAction(string.Format("{0} {1} {2}", person.FirstName, person.LastName, person.Age));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NestedObject(PersonWithAddressViewModel person)
        {
            return this.SetTempDataAndRedirectToAction(string.Format("{0} {1} {2}", person.Name, person.Address.City, person.Address.Country));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CollectionOfPrimitiveTypes(IEnumerable<string> strings)
        {
            return this.SetTempDataAndRedirectToAction(string.Join(", ", strings));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CollectionOfObjects(IEnumerable<PersonViewModel> persons)
        {
            var result = new StringBuilder();
            foreach (var person in persons)
            {
                result.AppendLine(string.Format("{0} {1} {2}", person.FirstName, person.LastName, person.Age));
            }

            return this.SetTempDataAndRedirectToAction(result.ToString());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CollectionOfFiles(IEnumerable<HttpPostedFileBase> files)
        {
            var names = files.Where(f => f != null).Select(f => f.FileName);
            return this.SetTempDataAndRedirectToAction(string.Join(", ", names));
        }

        private ActionResult SetTempDataAndRedirectToAction(string msg)
        {
            TempData["Success"] = msg;
            return RedirectToAction("Index");
        }
    }
}