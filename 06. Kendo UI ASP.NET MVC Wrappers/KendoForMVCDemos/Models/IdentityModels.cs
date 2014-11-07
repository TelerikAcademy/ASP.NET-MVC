using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace KendoForMVCDemos.Models
{
    // You can add profile data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : User
    {
        public string City { get; set; }

        public string Country { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContextWithCustomUser<ApplicationUser>
    {
        public DbSet<Book> Books { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}