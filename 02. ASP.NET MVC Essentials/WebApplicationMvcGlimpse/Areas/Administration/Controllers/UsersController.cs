using System.Web.Mvc;
using WebApplicationMvcGlimpse.Controllers;

namespace WebApplicationMvcGlimpse.Areas.Administration.Controllers
{
    [Authorize(Roles="Admin")]
    public class UsersController : AdminController
    {
        //
        // GET: /Administration/Users/
        public ActionResult ViewAll()
        {
            return View();
        }
	}
}