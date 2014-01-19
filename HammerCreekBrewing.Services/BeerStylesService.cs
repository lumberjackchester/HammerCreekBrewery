using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HammerCreekBrewing.Data.Models;
using HammerCreekBrewing.Data;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;



namespace HammerCreekBrewing.Services
{
    public class BeerStyleService : IBeerStylesService
    {
        private readonly IUnitOfWork _uow;
        public BeerStyleService(IUnitOfWork unit)
        {
            _uow = unit;
        }

        public IQueryable<BeerStyle> GetBeerStyles()
        {
            return _uow.BeerStyles.GetAll();
        }
        public async Task<List<BeerStyle>> GetBeerStylesAsync()
        {

            var styles = await GetBeerStyles().ToListAsync();
            return styles;
        }

    }
}
