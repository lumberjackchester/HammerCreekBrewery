using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HammerCreekBrewing.Data.Models; 

namespace HammerCreekBrewing.Data.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<BeerMenuViewModel> BeerOnTapInside { get; set; }
        public IEnumerable<BeerMenuViewModel> BeerOnTapGarage { get; set; }
        public IEnumerable<BeerMenuViewModel> BeerInFridge { get; set; }
               
    }
}