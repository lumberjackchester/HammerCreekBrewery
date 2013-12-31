using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HammerCreekBrewing.Models
{
    public class Beer
    {
        [Key]
        [Required]
        public int BeerId { get; set; }
        [Required]
        public string Name { get; set; }
        
        [ForeignKey("StyleId")]
        public Style Style { get; set; }

        [Required]
        public int StyleId { get; set; }
        public string TapName { get; set; }
        public string LocationId { get; set; }
        [Required]
        public DateTime BrewDate { get; set; }
        public DateTime? KeggedDate { get; set; }
        public DateTime? TappedDate { get; set; }
        [Required]
        public decimal Abv { get; set; }
        public int? KegId { get; set; }
        [Required]
        public bool OnTap { get; set; }

    }
}