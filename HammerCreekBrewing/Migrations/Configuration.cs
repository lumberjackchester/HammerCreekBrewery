namespace HammerCreekBrewing.Migrations
{
    using Domain;
    using Repository;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Repository.RepositoryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Repository.RepositoryContext context)
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

            context.Styles.AddOrUpdate(new Style { Id = 1, StyleName = "WitBier" });
            context.Styles.AddOrUpdate(new Style { Id = 2, StyleName = "Stout" });
            context.Beers.AddOrUpdate(new Beer { Id = 1, StyleId = 1, Name = "Peach On Wit", BrewDate = new DateTime(2013, 9, 28) });
        }
    }
}
