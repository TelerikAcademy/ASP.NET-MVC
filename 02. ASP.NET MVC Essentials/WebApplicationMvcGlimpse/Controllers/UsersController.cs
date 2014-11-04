using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationMvcGlimpse.App_Start;

namespace WebApplicationMvcGlimpse.Controllers
{
    public class Params
    {
        public int IntValue { get; set; }

        [AllowHtml]
        public string StringValue { get; set; }

        public string Username { get; set; }
    }

    [Log]
    public class UsersController : Controller
    {
        public ActionResult ByUsername(Params @params)
        {
            return View(@params);
        }

        [NonAction]
#if !DEBUG
        [RequireHttps]
#endif
        public string GetServerPassword()
        {
            return "g00gl3!";
        }
    }
}