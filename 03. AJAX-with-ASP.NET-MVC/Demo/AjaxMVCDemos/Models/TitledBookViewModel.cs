using System;
using System.Linq.Expressions;
namespace AjaxMVCDemos.Models
{
    public class TitledBookViewModel
    {
        public static Expression<Func<Book, TitledBookViewModel>> FromBook
        {
            get
            {
                return book => new TitledBookViewModel
                {
                    Title = book.Title,
                };
            }
        }

        public string Title { get; set; }
    }
}