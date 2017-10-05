using System;
using TelerikAcademy.ForumSystem.Data.Model.Abstracts;

namespace TelerikAcademy.ForumSystem.Data.Model
{
    public class Post : DataModel
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public virtual User Author { get; set; }
    }
}
