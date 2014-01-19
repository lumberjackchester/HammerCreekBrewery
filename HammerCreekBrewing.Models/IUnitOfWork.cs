using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using HammerCreekBrewing.Data.Models;
using System.Threading.Tasks;

namespace HammerCreekBrewing.Data
{
    public interface IUnitOfWork 
    {
        HCBContext DbContext { get; set; }

        // Save pending changes
        void Commit();
        Task<int> CommitAsync();

        // Profile reference repositories
        IRepository<Beer> Beers { get; }
        IRepository<BeerStyle> BeerStyles { get; } 
        IRepository<Location> Locations { get; }
        IRepository<Brewery> Breweries { get; }
    }
}
