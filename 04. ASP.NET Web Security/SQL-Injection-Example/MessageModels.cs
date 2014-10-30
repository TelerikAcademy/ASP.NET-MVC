using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SQL_Injection_Example
{
    public class Message
    {
        public int MessageId { get; set; }

        public DateTime MessageDate { get; set; }

        [Required, MaxLength(1000)]
        public string MessageText { get; set; }
    }

    public class MessagesDbContext : DbContext
    {
        public MessagesDbContext() : base("DbConnection")
        {
        }

        public DbSet<Message> Messages { get; set; }
    }

    public class MessagesDbInitializer : DropCreateDatabaseIfModelChanges<MessagesDbContext>
    {
        protected override void Seed(MessagesDbContext dbContext)
        {
            dbContext.Messages.Add(new Message() { MessageText = "First message (~ almost)", MessageDate = DateTime.Now });
            dbContext.Messages.Add(new Message() { MessageText = "Second message (30% done)", MessageDate = DateTime.Now });
            dbContext.Messages.Add(new Message() { MessageText = "I am 100% big message (like 30 smaller messages)", MessageDate = DateTime.Now });
            dbContext.Messages.Add(new Message() { MessageText = "I am ~ 30% message", MessageDate = DateTime.Now });
            dbContext.Messages.Add(new Message() { MessageText = "Last message (90% ready)", MessageDate = DateTime.Now });
        }
    }
}
