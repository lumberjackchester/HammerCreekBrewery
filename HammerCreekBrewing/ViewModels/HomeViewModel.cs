using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HammerCreekBrewing.Models;
using HammerCreekBrewing.Services;

namespace HammerCreekBrewing.ViewModels
{
    public class HomeViewModel
    {
        private readonly IBeerService _beerService;
        public IEnumerable<Beer> BeerOnTap { get; set; }
        public IEnumerable<Beer> BeerInFridge { get; set; }

        public HomeViewModel(IBeerService beerService)
        {
            BeerOnTap = beerService.GetBeerOnTap().ToList();
            BeerInFridge = beerService.GetBeerInFridge().ToList();
        }
    }
}