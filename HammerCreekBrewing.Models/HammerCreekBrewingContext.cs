using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerCreekBrewing.Models{
    public class HCBContext : DbContext {
        public HCBContext()
            : base("name=DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        
        public DbSet<Beer> Beers { get; set; }
        public DbSet<BeerStyle> BeerStyles {get; set;}

    }
}
