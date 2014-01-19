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
        public IEnumerable<BeerViewModel> BeerOnTapInside { get; set; }
        public IEnumerable<BeerViewModel> BeerOnTapGarage { get; set; }
        public IEnumerable<BeerViewModel> BeerInFridge { get; set; }

        //public HomeViewModel()
        //{
        //   // BeerOnTap = beerService.GetBeerOnTap().ToList();
        //    BeerInFridge = beerService.GetBeerInFridge().ToList();
        //    BeerOnTapInside = beerService.GetBeerOnTapInside().ToList();
        //    BeerOnTapGarage = beerService.GetBeerOnTapGarage().ToList();
        //}
    }
}