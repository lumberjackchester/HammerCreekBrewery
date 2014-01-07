using HammerCreekBrewing.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 


namespace HammerCreekBrewing.Services
{
    public interface IBeerService
    {
         List<BeerDto> GetCurrentMenu();
         List<BeerDto> GetAllBeers();
         BeerDto GetBeer(int id);

    }
}
