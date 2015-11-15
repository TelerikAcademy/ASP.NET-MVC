using System.Web.Mvc;

namespace WebApplicationMvcGlimpse.Controllers
{
    [Authorize(Roles="Admin")]
    public class AdminController : Controller
    {
    }
}