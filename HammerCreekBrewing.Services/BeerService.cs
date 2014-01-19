using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HammerCreekBrewing.Data.Models;
using HammerCreekBrewing.Data;
using HammerCreekBrewing.Data.Enums;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;

namespace HammerCreekBrewing.Services
{
    public class BeerService : IBeerService
    {
       // private readonly HCBContext _uow = new HCBContext();
        //private readonly Expression<Func<Beer, BeerDto>> AsBeerDto = x => new BeerDto { Name = x.Name, Style = x.Style.StyleName };

        private readonly IUnitOfWork _uow;
        public BeerService(IUnitOfWork unit)
        {
            _uow = unit;
        }

        public IQueryable<Beer> GetBeerOnTap()
        {
            return _uow.Beers.GetAll().Where(b => b.OnTap);
        }
        public IQueryable<Beer> GetBeerOnTapInside()
        {
            return GetBeerOnTap().Where(b => b.LocationId == (int)Locations.Basement);
        }
        public IQueryable<Beer> GetBeerOnTapGarage()
        {
            return GetBeerOnTap().Where(b => b.LocationId == (int)Locations.Garage);
        }
        public IQueryable<Beer> GetBeerInFridge()
        {
            return _uow.Beers.GetAll().Where(b => !b.OnTap);
        }
        public async Task<List<Beer>> GetBeerOnTapAsync()
        { 
            return await GetBeerOnTap().ToListAsync();
        }
        public async Task<List<Beer>> GetAllBeersAsync()
        {
            var beers = await _uow.Beers.GetAllIncluding(b => b.Style).ToListAsync();
            return beers;
        }
        public async Task<Beer> GetBeerAsync(int? id)
        {
            var beer = await _uow.Beers.GetAllIncluding(b => b.Style).Where(b => b.BeerId == id).FirstOrDefaultAsync();
            return beer ;
        }
    }

    
}