using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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