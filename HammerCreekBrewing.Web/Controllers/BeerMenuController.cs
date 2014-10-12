using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description; 
using HammerCreekBrewing.Services;
using HammerCreekBrewing.Data.ViewModels;

namespace HammerCreekBrewing.Web.Controllers
{
    public class BeerMenuController : ApiController
    {           
               
        private readonly IBeerService _beerService;
        private readonly ILogging _logger;

        public BeerMenuController(IBeerService ibeerservice, ILogging ilogger)
        {
            _beerService = ibeerservice;
            _logger = ilogger;
        }

        // GET api/BeerMenu
        //public async Task<List<BeerMenuViewModel>> GetBeers()
        public IHttpActionResult GetBeerMenu()
        {

            var homeVM = new HomeViewModel();
            homeVM.AllBeer = _beerService.GetAllBeers<BeerViewModel>();
            homeVM.AllLocations = _beerService.GetAllLocations<LocationViewModel>();
          //  homeVM.BeerOnTapInside = _beerService.GetBeerOnTapInside<BeerMenuViewModel>();
            //homeVM.BeerOnTapGarage = await _beerService.GetBeerOnTapGarage<BeerMenuViewModel>();
            //homeVM.BeerInFridge = await _beerService.GetBeerInFridge<BeerMenuViewModel>();

           // var allBeers = await _beerService.GetAllBeersAsync<BeerMenuViewModel>();
            if (homeVM == null)
            {
                return NotFound();
            }
            return Ok(homeVM);
        }

        // GET api/BeerMenu/5
        [ResponseType(typeof(BeerViewModel))]
        public async Task<IHttpActionResult> GetBeer(int id)
        {
            var thisBeer = await _beerService.GetBeerAsync<BeerViewModel>(id);
            if (thisBeer == null)
            {
                return NotFound();
            }

            return Ok(thisBeer);
        }

    }
}