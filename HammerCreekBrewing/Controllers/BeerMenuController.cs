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

namespace HammerCreekBrewing.Controllers
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
        public async Task<IHttpActionResult> GetBeerMenu()
        {
            var allBeers = await _beerService.GetAllBeersAsync<BeerMenuViewModel>();
            if (allBeers == null)
            {
                return NotFound();
            }
            return Ok(allBeers);
        }

        // GET api/BeerMenu/5
        [ResponseType(typeof(ViewModels.BeerMenuViewModel))]
        public async Task<IHttpActionResult> GetBeer(int id)
        {
            var thisBeer = await _beerService.GetBeerAsync<BeerMenuViewModel>(id);
            if (thisBeer == null)
            {
                return NotFound();
            }

            return Ok(thisBeer);
        }

    }
}