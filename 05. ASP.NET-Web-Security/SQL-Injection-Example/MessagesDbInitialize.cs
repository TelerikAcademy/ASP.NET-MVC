namespace SQL_Injection_Example
{
    using System;
    using System.Data.Entity;

    public class MessagesDbInitialize : DropCreateDatabaseIfModelChanges<MessagesDbContext>
    {
        protected override void Seed(MessagesDbContext context)
        {
            context.Messages.Add(new Message { MessageText = "First message (~ almost)", MessageDate = DateTime.Now });
            context.Messages.Add(new Message { MessageText = "Second message (30% done)", MessageDate = DateTime.Now });
            context.Messages.Add(new Message { MessageText = "I am 100% big message (like 30 smaller messages)", MessageDate = DateTime.Now });
            context.Messages.Add(new Message { MessageText = "I am ~ 30% message", MessageDate = DateTime.Now });
            context.Messages.Add(new Message { MessageText = "Last message (90% ready)", MessageDate = DateTime.Now });
        }
    }
}
