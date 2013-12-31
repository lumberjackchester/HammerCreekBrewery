namespace HammerCreekBrewing.Migrations
{
    using HammerCreekBrewing.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HammerCreekBrewing.Models.HammerCreekBrewingContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HammerCreekBrewing.Models.HammerCreekBrewingContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Styles.AddOrUpdate(new Style { StyleId = 1, StyleName = "WitBier" });
            context.Styles.AddOrUpdate(new Style { StyleId = 2, StyleName = "Stout" });
            context.Beers.AddOrUpdate(new Beer { BeerId = 1, StyleId = 1, Name = "Peach On Wit", BrewDate = new DateTime(2013, 9, 28) });
        }
    }
}
