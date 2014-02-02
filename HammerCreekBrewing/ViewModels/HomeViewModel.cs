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
        public List<BeerMenuViewModel> BeerOnTapInside { get; set; }
        public List<BeerMenuViewModel> BeerOnTapGarage { get; set; }
        public List<BeerMenuViewModel> BeerInFridge { get; set; }
               
    }
}