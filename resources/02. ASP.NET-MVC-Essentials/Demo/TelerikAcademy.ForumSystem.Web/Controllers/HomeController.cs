using AutoMapper;
using System.Linq;
using System.Web.Mvc;
using TelerikAcademy.ForumSystem.Services;
using TelerikAcademy.ForumSystem.Web.Models.Home;

namespace TelerikAcademy.ForumSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostsService postsService;
        private readonly IMapper mapper;

        public HomeController(IPostsService postsService, IMapper mapper)
        {
            this.postsService = postsService;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var posts = this.postsService
                .GetAll()
                .Select(x => this.mapper.Map<PostViewModel>(x))
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