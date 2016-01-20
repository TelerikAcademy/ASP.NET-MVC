namespace WorkingWithDataMvc.Data
{
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;

    using WorkingWithDataMvc.Models;

    public class DataContext : IdentityDbContextWithCustomUser<ApplicationUser>
    {
        public virtual IDbSet<BlogPost> BlogPosts { get; set; }

        public virtual IDbSet<Comment> Comments { get; set; }
    }
}
