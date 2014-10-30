using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AjaxMVCDemos.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public decimal Sales { get; set; }

        public decimal Taxes { get; set; }
    }
}