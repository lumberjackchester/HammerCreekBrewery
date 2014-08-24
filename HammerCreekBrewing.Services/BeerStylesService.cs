using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HammerCreekBrewing.Data.Entities;
using HammerCreekBrewing.Data;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;



namespace HammerCreekBrewing.Services
{
    public class BeerStyleService : IBeerStylesService
    {
        private readonly HammerCreekBrewing.Data.HCBContext _db;
        public BeerStyleService(HCBContext db)
        {
            _db = db;
        }

        public IQueryable<BeerStyle> GetBeerStyles()
        {
            return _db.BeerStyles;
        }
        public async Task<List<BeerStyle>> GetBeerStylesAsync()
        {

            var styles = await _db.BeerStyles.ToListAsync();
            return styles;
        }

    }
}
