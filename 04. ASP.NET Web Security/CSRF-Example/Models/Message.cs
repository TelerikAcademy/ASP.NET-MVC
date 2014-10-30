using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CSRF_Example.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        
        public DateTime MessageDate { get; set; }
        
        [Required, MaxLength(1000)]
        public string MessageText { get; set; }
    }
}
