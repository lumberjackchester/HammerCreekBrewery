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
using AutoMapper;

namespace HammerCreekBrewing.Services
{
    public class BeerService : IBeerService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMappingEngine _mapper;
        public BeerService(IUnitOfWork unit, IMappingEngine mapper)
        {
            _uow = unit;
            _mapper = mapper;
        }

        public IQueryable<Beer> GetBeerOnTap()
        {
            return _uow.Beers.GetAll().Where(b => b.OnTap);
        }
        //public IQueryable<Beer> GetBeerOnTapInside()
        //{
        //    return GetBeerOnTap().Where(b => b.LocationId == (int)Locations.Basement);
        //}
        //public IQueryable<Beer> GetBeerOnTapGarage()
        //{
        //    return GetBeerOnTap().Where(b => b.LocationId == (int)Locations.Garage);
        //}
        //public IQueryable<Beer> GetBeerInFridge()
        //{
        //    return _uow.Beers.GetAll().Where(b => !b.OnTap);
        //}


        //public List<T> GetBeerOnTap<T>()
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<List<T>> GetBeerOnTapInside<T>()
        {
            var bOntap = await GetBeerOnTap().Where(b => b.LocationId == (int)Locations.Basement).ToListAsync();
            return _mapper.Map<List<Beer>, List<T>>(bOntap);                 
        }

        public async Task<List<T>> GetBeerOnTapGarage<T>()
        {
            var bOntap =  await GetBeerOnTap().Where(b => b.LocationId == (int)Locations.Garage).ToListAsync();
            return _mapper.Map<List<Beer>, List<T>>(bOntap);      
        }

        public async Task<List<T>> GetBeerInFridge<T>()
        {
            var bOntap =   await GetBeerOnTap().Where(b => !b.OnTap).ToListAsync();
            return _mapper.Map<List<Beer>, List<T>>(bOntap);      
        }
         

        /// <summary>
        /// Gets Beer On Tap and maps Beer entity to type T
        /// </summary>
        /// <typeparam name="T">The return type to map the beer enity</typeparam>
        /// <returns></returns>
        public async Task<List<T>> GetBeerOnTapAsync<T>()
        {
            var bOntap = await GetBeerOnTap().ToListAsync();
            return _mapper.Map<List<Beer>, List<T>>(bOntap);
        }
        public async Task<List<T>> GetAllBeersAsync<T>()
        {
            var beers = await _uow.Beers.GetAllIncluding(b => b.Style).ToListAsync();
            return _mapper.Map<List<Beer>, List<T>>(beers); ;
        }
        public async Task<T> GetBeerAsync<T>(int id)
        {
            var beer = await _uow.Beers.GetAllIncluding(b => b.Style).Where(b => b.BeerId == id).FirstOrDefaultAsync();
            return _mapper.Map<Beer, T>(beer); ;
        }
        public async Task<T> GetBeerModelAsync<T>(int id)
        {

            var beer = await _uow.Beers.GetAllIncluding(b => b.Style).Where(b => b.BeerId == id).FirstOrDefaultAsync();
            return _mapper.Map<Beer, T>(beer);
        }
         

    }

    
}