using HammerCreekBrewing.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 


namespace HammerCreekBrewing.Services
{
    public interface IBeerStylesService
    {
        IQueryable<BeerStyle> GetBeerStyles();
        
        Task<List<BeerStyle>> GetBeerStylesAsync();
         
    }
}
