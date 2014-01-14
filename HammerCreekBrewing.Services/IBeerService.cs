using HammerCreekBrewing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 


namespace HammerCreekBrewing.Services
{
    public interface IBeerService
    {
        IQueryable<Beer> GetBeerOnTap();
        IQueryable<Beer> GetBeerInFridge();
         Task<List<Beer>> GetBeerOnTapAsync();
         Task<List<Beer>> GetAllBeersAsync();
         Task<Beer> GetBeerAsync(int id);

    }
}
