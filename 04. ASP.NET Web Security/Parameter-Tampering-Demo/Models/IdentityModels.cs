using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Parameter_Tampering_Demo.Models
{
    public class ApplicationUser : User
    {
        public UserProfile Profile { get; set; }
    }

    public class UserProfile
    {
        public int UserProfileId { get; set; }

        [MinLength(1), MaxLength(100)]
        public string FirstName { get; set; }

        [MinLength(1), MaxLength(100)]
        public string LastName { get; set; }

        public decimal Credit { get; set; }

        public virtual User User { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContextWithCustomUser<ApplicationUser>
    {
        public DbSet<UserProfile> UserProfiles { get; set; }
    }
}
