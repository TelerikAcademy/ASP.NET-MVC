using System.Web.Mvc;

namespace WebApplicationMvcGlimpse.Controllers
{
    public class UsersAdminController : AdminController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}