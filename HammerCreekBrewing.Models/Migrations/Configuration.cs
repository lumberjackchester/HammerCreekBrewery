namespace HammerCreekBrewing.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;
    using WebMatrix.WebData;
    using HammerCreekBrewing.Data.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<HammerCreekBrewing.Data.HCBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HammerCreekBrewing.Data.HCBContext context)
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

            if (System.Configuration.ConfigurationManager.AppSettings["DatabaseContextInitializer"] == "DropAndRecreate")
            {
                SeedDevDB(context);
            }
            //else if (System.Configuration.ConfigurationManager.AppSettings["DatabaseContextInitializer"] == "CreateIfNotExists")
            //    Database.SetInitializer(new ProductionContextInitializer());
            //else
            //    Database.SetInitializer<HCBContext>(null);
        }

        private void SeedDevDB(HCBContext db)
        {
            //WebSecurity.InitializeDatabaseConnection("HammerCreekBrewingContext",
            //      "UserProfile", "UserId", "UserName", autoCreateTables: true);
            //var roles = (SimpleRoleProvider)Roles.Provider;
            //var membership = (SimpleMembershipProvider)Membership.Provider;

            //if (!roles.RoleExists("Admin"))
            //{
            //    roles.CreateRole("Admin");
            //}
            //if (membership.GetUser("Administrator", false) == null)
            //{
            //    membership.CreateUserAndAccount("Administrator", "AR15#22");
            //}
            //if (!roles.GetRolesForUser("Administrator").Contains("Admin"))
            //{
            //    roles.AddOrUpdateUsersToRoles(new[] { "Administrator" }, new[] { "Admin" });
            //}

            // Database data initialization -- needs expanding upon.
            #region Data initialization

            #region Breweries
            db.Breweries.AddOrUpdate(new Brewery { BreweryId = 1, Name = "Hammer Creek Brewing" });
            db.Breweries.AddOrUpdate(new Brewery { BreweryId = 2, Name = "Delirium" });
            #endregion

            #region Locations

            db.Locations.AddOrUpdate(new Location { LocationId = 1, Name = "Basement" });
            db.Locations.AddOrUpdate(new Location { LocationId = 2, Name = "Garage" });
            db.Locations.AddOrUpdate(new Location { LocationId = 3, Name = "Storage" });

            #endregion

            #region BeerStyles

            db.BeerStyles.AddOrUpdate(new BeerStyle { BeerStyleId = 1, StyleName = "WitBier" });
            db.BeerStyles.AddOrUpdate(new BeerStyle { BeerStyleId = 2, StyleName = "Stout" });
            db.BeerStyles.AddOrUpdate(new BeerStyle { BeerStyleId = 3, StyleName = "Ale" });
            db.BeerStyles.AddOrUpdate(new BeerStyle { BeerStyleId = 4, StyleName = "Belgium" });

            #endregion

            #region Beers


            db.Beers.AddOrUpdate(new Beer { BeerId = 1, StyleId = 1, LocationId = (int)Enums.Locations.Storage, BreweryId = 1, Name = "Peach On Wit", BrewDate = new DateTime(2013, 9, 28) });
            db.Beers.AddOrUpdate(new Beer { BeerId = 2, StyleId = 2, LocationId = (int)Enums.Locations.Storage, BreweryId = 1, Name = "Milk Stout", BrewDate = new DateTime(2013, 9, 28) });
            db.Beers.AddOrUpdate(new Beer { BeerId = 3, StyleId = 3, LocationId = (int)Enums.Locations.Basement, BreweryId = 1, OnTap = true, Name = "Pumpkin Ale", BrewDate = new DateTime(2013, 9, 28) });
            db.Beers.AddOrUpdate(new Beer { BeerId = 4, StyleId = 3, LocationId = (int)Enums.Locations.Garage, BreweryId = 1, Name = "Tremens", BrewDate = new DateTime(2013, 9, 28) });

            #endregion

            #endregion

        }
    }
}
