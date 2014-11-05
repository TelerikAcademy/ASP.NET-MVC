namespace WorkingWithDataMvc.Controllers
{
    using System.Web.Mvc;

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
            TempData["Success"] = string.Format("{0} {1} {2}", first, second, third);
            return RedirectToAction("Index");
        }
    }
}