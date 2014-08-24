﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HammerCreekBrewing.Data.Entities
{
    public class Brewery
    {
        [Key]
        public int BreweryId { get; set; }
        [Required]
        public string Name { get; set; }
        
    }
}