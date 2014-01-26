using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HammerCreekBrewing.Data.Models;
using HammerCreekBrewing.Services;

namespace HammerCreekBrewing.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<BeerMenuViewModel> BeerOnTapInside { get; set; }
        public IEnumerable<BeerMenuViewModel> BeerOnTapGarage { get; set; }
        public IEnumerable<BeerMenuViewModel> BeerInFridge { get; set; }
               
    }
}