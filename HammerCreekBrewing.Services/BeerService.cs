using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HammerCreekBrewing.Dtos;
using HammerCreekBrewing.Models;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace HammerCreekBrewing.Services
{
    public class BeerService : IBeerService
    {

        private HammerCreekBrewingContext db = new HammerCreekBrewingContext();
        private readonly Expression<Func<Beer, BeerDto>> AsBeerDto = x => new BeerDto { Name = x.Name, Style = x.Style.StyleName };
        public List<BeerDto> GetCurrentMenu()
        {
            return new List<BeerDto>();
        }
        public List<BeerDto> GetAllBeers()
        {
           return db.Beers.Include(b => b.Style).Select(AsBeerDto).ToList();
        }
        public BeerDto GetBeer(int id)
        {
            var beer = db.Beers.Include(b => b.Style).Where(b => b.BeerId == id).Select(AsBeerDto).FirstOrDefault();
            return beer ;
        }
    }
}