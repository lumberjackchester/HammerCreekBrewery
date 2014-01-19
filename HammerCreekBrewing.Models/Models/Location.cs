using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HammerCreekBrewing.Data.Models
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }
        [Required]
        public string Name { get; set; }
        
    }
}