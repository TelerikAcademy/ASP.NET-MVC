using KendoForMVCDemos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace KendoForMVCDemos.ViewModels
{
    public class ShortBookViewModel
    {
        public static Expression<Func<Book, ShortBookViewModel>> FromBook
        {
            get
            {
                return book => new ShortBookViewModel
                {
                    Id = book.Id,
                    Title = book.Title
                };
            }
        }

        public int Id { get; set; }

        public string Title { get; set; }
    }
}