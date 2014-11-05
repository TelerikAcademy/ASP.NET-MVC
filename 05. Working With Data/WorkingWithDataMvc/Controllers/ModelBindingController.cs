namespace WorkingWithDataMvc.Controllers
{
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

        private ActionResult SetTempDataAndRedirectToAction(string msg)
        {
            TempData["Success"] = msg;
            return RedirectToAction("Index");
        }
    }
}