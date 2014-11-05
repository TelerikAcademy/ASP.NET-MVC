namespace WorkingWithDataMvc.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Data;
    using Models;

    public class HomeController : BaseController
    {
        public HomeController(IUowData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            var blogPost = new BlogPost { Title = "My first blog post", Content = "Blog post content" };
            Data.BlogPosts.Add(blogPost);

            if (User.Identity.IsAuthenticated)
            {
                var user = Data.Users.All().FirstOrDefault(x => x.UserName == User.Identity.Name);
                Data.Comments.Add(new Comment { Author = user, BlogPost = blogPost, Content = "Spam!" });
            }

            Data.SaveChanges();

            return View();
        }
    }
}