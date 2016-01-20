namespace CSRF_Example.Controllers
{
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }
        
        [ActionName("XSS-MVC")]
        //// Un-comment following line to allow HTML in query strings
        //// [ValidateInput(false)]
        //// Observe the Google Chrome reaction to <script>alert(...)</script>
        public ActionResult XssMvc(string someInput)
        {
            if (!string.IsNullOrWhiteSpace(someInput))
            {
                this.ViewBag.SomeInput = someInput;
            }
            else
            {
                this.ViewBag.SomeInput = "<script>alert('XSS');</script>";
            }

            return this.View("XSS-MVC");
        }
    }
}
