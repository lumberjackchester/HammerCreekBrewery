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
using HammerCreekBrewing.Models;
using HammerCreekBrewing.Services;

namespace HammerCreekBrewing.Controllers
{
    public class BeerMenuController : ApiController
    {
      //  private HCBContext db = new HCBContext();


        private readonly IBeerService _beerService;
        private readonly ILogging _logger;

        public BeerMenuController(IBeerService ibeerservice, ILogging ilogger)
        {
            _beerService = ibeerservice;
            _logger = ilogger;
        }

        // GET api/BeerMenu
       // public async Task<List<Beer>> GetBeers()
        public async Task<IHttpActionResult> GetBeerMenu()
        {
            var allBeers = await _beerService.GetCurrentMenu();
            if (allBeers == null)
            {
                return NotFound();
            }
            return Ok(allBeers);
        }

        // GET api/BeerMenu/5
        [ResponseType(typeof(Beer))]
        public async Task<IHttpActionResult> GetBeer(int id)
        { 
            var thisBeer = await _beerService.GetBeerAsync(id);
            if (thisBeer == null)
            {
                return NotFound();
            }

            return Ok(thisBeer);
        }

    }
}