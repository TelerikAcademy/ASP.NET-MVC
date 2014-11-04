namespace SQL_Injection_Example
{
    using System.Data.Entity;

    public class MessagesDbContext : DbContext
    {
        public MessagesDbContext() : base("DbConnection")
        {
        }

        public DbSet<Message> Messages { get; set; }
    }
}