using AjaxMVCDemos.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace AjaxMVCDemos.ViewModels
{
    public class BookViewModel
    {
        public static Expression<Func<Book, BookViewModel>> FromBook
        {
            get
            {
                return book => new BookViewModel
                {
                    Id = book.Id,
                    Title = book.Title,
                    Content = book.Content
                };
            }
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}