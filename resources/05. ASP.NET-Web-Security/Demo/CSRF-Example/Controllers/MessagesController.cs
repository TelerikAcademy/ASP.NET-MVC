namespace CSRF_Example.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using CSRF_Example.Models;

    [Authorize]
    [ValidateInput(false)]
    public class MessagesController : Controller
    {
        public ActionResult Index()
        {
            this.LoadMessages();
            return this.View();
        }

        // [ValidateAntiForgeryToken]
        public ActionResult CreateMessage(Message msg)
        {
            if (ModelState.IsValid)
            {
                msg.MessageDate = DateTime.Now;
                var context = new ApplicationDbContext();
                
                context.Messages.Add(msg);
                context.SaveChanges();

                return this.RedirectToAction("Index");
            }

            this.LoadMessages();
            return this.View("Index", msg);
        }

        private void LoadMessages()
        {
            var context = new ApplicationDbContext();
            this.ViewBag.Messages = context.Messages.ToList();
        }
    }
}
