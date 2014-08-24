using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HammerCreekBrewing.Data.Entities
{
    public class BeerStyle
    {
        [Key]
        public int BeerStyleId { get; set; }
        [Required]
        public string StyleName { get; set; }
        
    }
}