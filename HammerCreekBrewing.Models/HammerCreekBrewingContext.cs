﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HammerCreekBrewing.Data.Models;

namespace HammerCreekBrewing.Data{
    public class HCBContext : DbContext {
        public HCBContext(string connectionString = "name=HammerCreekBrewingContext")
            : base(connectionString)
         //   : base("name=HammerCreekBrewingContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public HCBContext()
            : base("name=HammerCreekBrewingContext") 
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        
        public DbSet<Beer> Beers { get; set; }
        public DbSet<BeerStyle> BeerStyles {get; set;}
        public DbSet<Location> Locations { get; set; }
        public DbSet<Brewery> Breweries { get; set; }
  

        //private string GetConnectionStringName()
        //{

        //}
    }
}
