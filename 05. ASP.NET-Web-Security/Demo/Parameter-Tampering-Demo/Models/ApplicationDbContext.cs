namespace Parameter_Tampering_Demo.Models
{
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;

    public class ApplicationDbContext : IdentityDbContextWithCustomUser<ApplicationUser>
    {
        public DbSet<UserProfile> UserProfiles { get; set; }
    }
}
