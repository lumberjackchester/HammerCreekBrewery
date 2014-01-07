using System.Data.Entity;
using HammerCreekBrewing.Domain;

namespace Repository
{
    public interface IUnitOfWork {

        IDbSet<Beer> Beers { get; set; }
        IDbSet<Style> Styles { get; set; } 

        int SaveChanges();
    }
} 
