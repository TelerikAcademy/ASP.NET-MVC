namespace WorkingWithDataMvc.Data
{
    using System;

    using WorkingWithDataMvc.Models;

    public interface IUowData : IDisposable
    {
        IRepository<Comment> Comments { get; }

        IRepository<BlogPost> BlogPosts { get; }

        IRepository<ApplicationUser> Users { get; }

        int SaveChanges();
    }
}
