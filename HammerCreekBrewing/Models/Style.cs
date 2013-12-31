using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HammerCreekBrewing.Models
{
    public class Style
    {
        [Key]
        public int StyleId { get; set; }
        [Required]
        public string StyleName { get; set; }
        
    }
}