using System.Linq;
using TelerikAcademy.ForumSystem.Data.Model;
using TelerikAcademy.ForumSystem.Data.Repositories;
using TelerikAcademy.ForumSystem.Data.SaveContext;

namespace TelerikAcademy.ForumSystem.Services
{
    public class PostsService : IPostsService
    {
        private readonly IEfRepository<Post> postsRepo;
        private readonly ISaveContext context;

        public PostsService(IEfRepository<Post> postsRepo, ISaveContext context)
        {
            this.postsRepo = postsRepo;
            this.context = context;
        }

        public IQueryable<Post> GetAll()
        {
            return this.postsRepo.All;
        }

        public void Update(Post post)
        {
            this.postsRepo.Update(post);
            this.context.Commit();
        }
    }
}
