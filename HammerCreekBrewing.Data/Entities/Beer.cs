using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HammerCreekBrewing.Data.Entities
{
    public class Beer
    {
        [Key]
        [Required]
        public int BeerId { get; set; }

        [Required]
        public string Name { get; set; }
        
        [ForeignKey("StyleId")]
        public BeerStyle Style { get; set; }

        [Required]
        public int StyleId { get; set; }
        public string TapName { get; set; }
        [ForeignKey("LocationId")]        
        public Location Location { get; set; }
        [Required]
        public int LocationId { get; set; }
        [Required]
        public DateTime BrewDate { get; set; }
        public DateTime? KeggedDate { get; set; }
        public DateTime? TappedDate { get; set; }
       // [Required]
        public string Abv { get; set; }
        public int? KegId { get; set; }
        [Required]
        public bool OnTap { get; set; }
        [ForeignKey("BreweryId")]
        public Brewery Brewery { get; set; }
        [Required]
        public int BreweryId { get; set; }
        

    }
}