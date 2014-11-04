namespace Parameter_Tampering_Demo.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Parameter_Tampering_Demo.Models;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return this.View();
            }
            else
            {
                return this.RedirectToAction("EditUserProfile/" + Server.UrlEncode(User.Identity.Name));
            }
        }

        public ActionResult EditUserProfile(string id)
        {
            var context = new ApplicationDbContext();
            var user = context.Users.Include("Profile").FirstOrDefault(u => u.UserName == id);
            ViewBag.user = user;
            return this.View();
        }

        public ActionResult DoEditUserProfile(string id, UserProfile profile)
        {
            var context = new ApplicationDbContext();
            var user = context.Users.Include("Profile").FirstOrDefault(u => u.UserName == id);
            profile.UserProfileId = user.Profile.UserProfileId;
            user.Profile = profile;
            context.SaveChanges();
            return this.RedirectToAction("Index");
        }
    }
}