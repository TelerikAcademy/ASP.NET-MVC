using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationMvcGlimpse.Models;

namespace WebApplicationMvcGlimpse.Controllers
{
    public class ProductsController : Controller
    {
        public ActionResult List()
        {
            var products = new List<Product>()
            {
                new Product() { Name = "Apple" },
                new Product() { Name = "Krisko's album" },
            };
            return PartialView("~/Views/Shared/_Form.cshtml", products);
        }
    }
}