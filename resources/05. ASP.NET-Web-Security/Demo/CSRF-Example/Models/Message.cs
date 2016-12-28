namespace CSRF_Example.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Message
    {
        public int MessageId { get; set; }
        
        public DateTime MessageDate { get; set; }
        
        [Required, MaxLength(1000)]
        public string MessageText { get; set; }
    }
}
