using System.Linq;
using TelerikAcademy.ForumSystem.Data.Model;

namespace TelerikAcademy.ForumSystem.Services
{
    public interface IPostsService
    {
        IQueryable<Post> GetAll();

        void AddPost(Post post);
    }
}