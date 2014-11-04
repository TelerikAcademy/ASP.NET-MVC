namespace Parameter_Tampering_Demo.Models
{
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNet.Identity.EntityFramework;

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
}