using Parameter_Tampering_Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Parameter_Tampering_Demo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (! User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return RedirectToAction("EditUserProfile/" + Server.UrlEncode(User.Identity.Name));
            }
        }

        public ActionResult EditUserProfile(string id)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();
            var user = dbContext.Users.Include("Profile").Where(u => u.UserName == id).FirstOrDefault();
            ViewBag.user = user;
            return View();
        }
    }
}