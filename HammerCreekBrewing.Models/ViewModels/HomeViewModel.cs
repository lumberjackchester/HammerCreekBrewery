﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HammerCreekBrewing.Data.Models; 

namespace HammerCreekBrewing.Data.ViewModels
{
    public class HomeViewModel
    {
        //public List<BeerMenuViewModel> BeerOnTapInside { get; set; }
        //public List<BeerMenuViewModel> BeerOnTapGarage { get; set; }
        //public List<BeerMenuViewModel> BeerInFridge { get; set; }
        public List<BeerViewModel> AllBeer { get; set; }
        public List<BreweryViewModel> AllBreweries { get; set; }
        public List<LocationViewModel> AllLocations { get; set; }
               
    }
}