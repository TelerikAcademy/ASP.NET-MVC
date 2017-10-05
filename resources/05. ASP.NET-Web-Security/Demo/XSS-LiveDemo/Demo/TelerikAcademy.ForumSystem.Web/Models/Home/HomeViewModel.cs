using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TelerikAcademy.ForumSystem.Data.Model;

namespace TelerikAcademy.ForumSystem.Web.Models.Home
{
    public class HomeViewModel
    {
        public ICollection<Post> Posts { get; set; }
    }
}