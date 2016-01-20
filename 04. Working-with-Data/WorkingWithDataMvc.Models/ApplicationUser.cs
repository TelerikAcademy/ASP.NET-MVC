namespace WorkingWithDataMvc.Models
{
    using System.Collections.Generic;

    using Microsoft.AspNet.Identity.EntityFramework;

    public class ApplicationUser : User
    {
        private ICollection<Comment> comments;
        
        public ApplicationUser()
        {
            this.comments = new HashSet<Comment>();
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}
