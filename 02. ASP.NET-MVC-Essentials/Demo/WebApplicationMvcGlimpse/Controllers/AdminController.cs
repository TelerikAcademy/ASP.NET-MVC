using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplicationMvcGlimpse.Controllers
{
    [Authorize(Roles="Admin")]
    public class AdminController : Controller
    {
    }
}