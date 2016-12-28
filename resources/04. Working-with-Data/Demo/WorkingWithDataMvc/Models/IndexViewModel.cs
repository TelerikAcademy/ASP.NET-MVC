using System;
using System.ComponentModel.DataAnnotations;

namespace WorkingWithDataMvc.Models
{
    public class IndexViewModel
    {
        public string Text { get; set; }

        public int Number { get; set; }

        public DateTime Date { get; set; }

        [UIHint("CustomDate")]
        public DateTime AnotherDate { get; set; }
    }
}