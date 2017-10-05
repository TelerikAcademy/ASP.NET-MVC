using AutoMapper;
using System.Linq;
using System.Web.Mvc;
using TelerikAcademy.ForumSystem.Data.Model;
using TelerikAcademy.ForumSystem.Services;
using TelerikAcademy.ForumSystem.Web.Models.Home;

namespace TelerikAcademy.ForumSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostsService postsService;

        public HomeController(IPostsService postsService)
        {
            this.postsService = postsService;
        }

        [HttpGet]
        [AjaxOnly]
        public ActionResult Index()
        {
            var posts = this.postsService
                .GetAll()
                .ToList();

            var viewModel = new HomeViewModel()
            {
                Posts = posts
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(PostViewModel model)
        {
            //this.postsService.Update()

            return this.RedirectToAction("Index");
        }

        [ValidateInput(false)]
        public ActionResult AddPost(Post post)
        {
            this.postsService.AddPost(post);
            return this.RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}