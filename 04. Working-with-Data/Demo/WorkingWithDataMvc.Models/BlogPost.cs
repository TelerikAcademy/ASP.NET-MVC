namespace WorkingWithDataMvc.Models
{
    using System.Collections.Generic;

    public class BlogPost
    {
        private ICollection<Comment> comments;

        public BlogPost()
        {
            this.comments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}
