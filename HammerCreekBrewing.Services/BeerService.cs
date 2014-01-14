using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HammerCreekBrewing.Models;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;

namespace HammerCreekBrewing.Services
{
    public class BeerService : IBeerService
    {
        private readonly HCBContext db = new HCBContext();
        //private readonly Expression<Func<Beer, BeerDto>> AsBeerDto = x => new BeerDto { Name = x.Name, Style = x.Style.StyleName };

        public IQueryable<Beer> GetBeerOnTap()
        {
            return db.Beers.Where(b => b.OnTap);
        }
        public IQueryable<Beer> GetBeerInFridge()
        {
            return db.Beers.Where(b => !b.OnTap);
        }
        public async Task<List<Beer>> GetBeerOnTapAsync()
        { 
            return await GetBeerOnTap().ToListAsync();
        }
        public async Task<List<Beer>> GetAllBeersAsync()
        {
            var beers = await db.Beers.Include(b => b.Style).ToListAsync();
            return beers;
        }
        public async Task<Beer> GetBeerAsync(int id)
        {
            var beer = await db.Beers.Include(b => b.Style).Where(b => b.BeerId == id).FirstOrDefaultAsync();
            return beer ;
        }
    }
}