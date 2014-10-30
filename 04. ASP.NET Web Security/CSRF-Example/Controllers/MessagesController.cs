using CSRF_Example.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CSRF_Example.Controllers
{
    [Authorize]
    [ValidateInput(false)]
    public class MessagesController : Controller
    {
        public ActionResult Index()
        {
            LoadMessages();
            return View();
        }

        private void LoadMessages()
        {
            var context = new ApplicationDbContext();
            this.ViewBag.Messages = context.Messages.ToList();
        }

        //[ValidateAntiForgeryToken]
        public ActionResult CreateMessage(Message msg)
        {
            if (ModelState.IsValid)
            {
                msg.MessageDate = DateTime.Now;
                using (var context = new ApplicationDbContext())
                {
                    context.Messages.Add(msg);
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }

            LoadMessages();
            return View("Index", msg);
        }
    }
}
