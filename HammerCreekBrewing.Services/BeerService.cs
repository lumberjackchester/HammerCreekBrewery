using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HammerCreekBrewing.Data.Entities;
using HammerCreekBrewing.Data;
using HammerCreekBrewing.Data.Enums;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using AutoMapper;
 
namespace HammerCreekBrewing.Services
{
     
    public class BeerService : IBeerService
    {
        private readonly HCBContext _db;
        public BeerService(HCBContext db)
        {
            _db = db;
        }

        public IQueryable<Beer> GetAllBeers()
        {
            return _db.Beers.Include(s => s.Style).Include(b => b.Brewery).Include(l=> l.Location);
        } 
        public IQueryable<Beer> GetBeerOnTap()
        {
            return GetAllBeers().Where(b => b.OnTap);
        }

        //public async Task<List<T>> GetBeerOnTapInside<T>()
        //{
        //    var bOntap = await GetBeerOnTap().Where(b => b.LocationId == (int)Locations.Basement).FirstOrDefaultAsync();
        //    var vms = Mapper.Map<Beer, T>(bOntap);
        //    return new List<T>{vms};
        //}
        public List<T> GetBeerOnTapInside<T>()
        {
            var bOntap =  GetBeerOnTap().Where(b => b.LocationId == (int)Locations.Basement).FirstOrDefault();
            var vms = Mapper.Map<Beer, T>(bOntap);
            return new List<T>{vms};
        }

        public async Task<List<T>> GetBeerOnTapGarage<T>()
        {
            var bOntap =  await GetBeerOnTap().Where(b => b.LocationId == (int)Locations.Garage).ToListAsync();
            return Mapper.Map<List<Beer>, List<T>>(bOntap);      
        }

        public async Task<List<T>> GetBeerInFridge<T>()
        {
            var bOntap = await _db.Beers.Where(b => !b.OnTap && b.LocationId == (int)Locations.Fridge).ToListAsync();
            return Mapper.Map<List<Beer>, List<T>>(bOntap);      
        }
         
        public async Task<List<T>> GetBeerInStorage<T>()
        {
            var bOntap = await _db.Beers.Where(b => !b.OnTap && b.LocationId == (int)Locations.Storage).ToListAsync();
            return Mapper.Map<List<Beer>, List<T>>(bOntap);      
        }
         

        /// <summary>
        /// Gets Beer On Tap and maps Beer entity to type T
        /// </summary>
        /// <typeparam name="T">The return type to map the beer enity</typeparam>
        /// <returns></returns>
        public async Task<List<T>> GetBeerOnTapAsync<T>()
        {
            var bOntap = await GetBeerOnTap().ToListAsync();
            return Mapper.Map<List<Beer>, List<T>>(bOntap);  
        }
        public List<T> GetAllBeers<T>()
        {
            var beers = GetAllBeers().ToList();

            return Mapper.Map<List<Beer>, List<T>>(beers);
        }
        public async Task<T> GetBeerAsync<T>(int id)
        {
            var beer = await _db.Beers.Where(b => b.BeerId == id).FirstOrDefaultAsync();
            return Mapper.Map<Beer, T>(beer); ;
        }
        public List<T> GetAllLocations<T>()
        {
            var beers = _db.Locations.ToList();

            return Mapper.Map<List<Location>, List<T>>(beers);
        }

    }

    
}