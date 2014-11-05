namespace WorkingWithDataMvc.Controllers
{
    using System;
    using System.Web.Mvc;
    using WorkingWithDataMvc.Models;

    public class TemplatesController : Controller
    {
        public ActionResult Index()
        {
            return View(new IndexViewModel
            {
                Text = "Some Text",
                Number = 15,
                Date = DateTime.Now
            });
        }
    }
}