using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HammerCreekBrewing.ViewModels
{
    public class BeerViewModel : EntityBaseViewModel
    { 
        public BeerStyleViewModel Style { get; set; } 
        public string TapName { get; set; } 
        public LocationViewModel Location { get; set; } 
        public DateTime BrewDate { get; set; }
        public DateTime? KeggedDate { get; set; }
        public DateTime? TappedDate { get; set; } 
        public decimal Abv { get; set; }
        public int? KegId { get; set; } 
        public BreweryViewModel Brewery { get; set; } 
    }
}