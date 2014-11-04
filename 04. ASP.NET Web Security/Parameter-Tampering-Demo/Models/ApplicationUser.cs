namespace Parameter_Tampering_Demo.Models
{
    using Microsoft.AspNet.Identity.EntityFramework;

    public class ApplicationUser : User
    {
        public UserProfile Profile { get; set; }
    }
}