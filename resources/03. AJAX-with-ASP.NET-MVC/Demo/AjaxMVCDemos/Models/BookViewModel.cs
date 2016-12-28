namespace AjaxMVCDemos.Models
{
    using System;
    using System.Linq.Expressions;

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