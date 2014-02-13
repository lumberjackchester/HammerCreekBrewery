using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HammerCreekBrewing.Data.ViewModels
{
    public class BeerMenuViewModel : EntityBaseViewModel
    {
        public int StyleId { get; set; }
        public string StyleName { get; set; } 
        public string TapName { get; set; } 
        public string LocationName { get; set; } 
        public string BrewDate { get; set; }
        public string KeggedDate { get; set; }
        public string TappedDate { get; set; } 
        public decimal Abv { get; set; }
        public int KegId { get; set; } 
        public string BreweryName { get; set; } 
    }
}