using AjaxMVCDemos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AjaxMVCDemos.Data
{
    public static class BooksData
    {
        public static Book GetBook()
        {
            return new Book
            {
                Id = 1,
                Title = "Don kihot",
                Content = "Don kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihot",
                Sales = 1000.0m,
                Taxes = 800.0m
            };
        }

        public static List<Book> GetAllBooks()
        {
            return new List<Book>
            {
                new Book
                    {
                        Id = 1,
                        Title = "Don kihot",
                        Content = "Don kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihotDon kihot",
                        Sales = 1000.0m,
                        Taxes = 800.0m
                    },
                     new Book
                    {
                        Id = 2,
                        Title = "Lord of the rings",
                        Content = "Frodo",
                        Sales = 120.0m,
                        Taxes = 5.0m
                    },
                     new Book
                    {
                        Id = 3,
                        Title = "Close your eyes",
                        Content = "Criminal",
                        Sales = 1500.0m,
                        Taxes = 70.0m
                    },
                     new Book
                    {
                        Id = 4,
                        Title = "Don kihot 5",
                        Content = "Bla",
                        Sales = 1800.0m,
                        Taxes = 90.0m
                    },
                     new Book
                    {
                        Id = 5,
                        Title = "Introduction to programming",
                        Content = "Twilight",
                        Sales = 500.0m,
                        Taxes = 68.0m
                    },

            };
        }
    }
}