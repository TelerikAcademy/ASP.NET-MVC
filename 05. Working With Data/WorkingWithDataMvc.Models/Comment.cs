namespace WorkingWithDataMvc.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public int BlogPostId { get; set; }

        public virtual BlogPost BlogPost { get; set; }

        public ApplicationUser Author { get; set; }

        public string Content { get; set; }
    }
}
