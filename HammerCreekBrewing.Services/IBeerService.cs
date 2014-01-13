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
        Task<List<Beer>> GetCurrentMenu();
         Task<List<Beer>> GetAllBeersAsync();
         Task<Beer> GetBeerAsync(int id);

    }
}
