namespace HammerCreekBrewing.Data.Migrations
{
    using HammerCreekBrewing.Data.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;
    using WebMatrix.WebData;
    using BeerEnums = HammerCreekBrewing.Data.Enums;

    internal sealed class Configuration : DbMigrationsConfiguration<HammerCreekBrewing.Data.HCBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(HammerCreekBrewing.Data.HCBContext db)
        { 
            //WebSecurity.InitializeDatabaseConnection("HammerCreekBrewingContext",
            //    "UserProfile", "UserId", "UserName", autoCreateTables: true);
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
            //    roles.AddUsersToRoles(new[] { "Administrator" }, new[] { "Admin" });
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

            db.BeerStyles.AddOrUpdate(new BeerStyle { BeerStyleId = (int)BeerEnums.BeerStyle.Witbier, StyleName = "Witbier" });
            db.BeerStyles.AddOrUpdate(new BeerStyle { BeerStyleId = (int)BeerEnums.BeerStyle.Stout, StyleName = "Stout" });
            db.BeerStyles.AddOrUpdate(new BeerStyle { BeerStyleId = (int)BeerEnums.BeerStyle.PaleAle, StyleName = "Pale Ale" });
            db.BeerStyles.AddOrUpdate(new BeerStyle { BeerStyleId = (int)BeerEnums.BeerStyle.BelgiumTripple, StyleName = "Belgium Tripple" });

            #endregion

            #region Beers


            db.Beers.AddOrUpdate(new Beer { BeerId = 1, StyleId = (int)BeerEnums.BeerStyle.Wit, LocationId = 2, BreweryId = 1, Name = "Peach On Wit", BrewDate = new DateTime(2013, 9, 28) });
            db.Beers.AddOrUpdate(new Beer { BeerId = 2, StyleId = (int)BeerEnums.BeerStyle.Stout, LocationId = 2, BreweryId = 1, Name = "Milk Stout", BrewDate = new DateTime(2013, 9, 28) });
            db.Beers.AddOrUpdate(new Beer
            {
                BeerId = 3,
                StyleId = 3,
                LocationId = 1,
                BreweryId = 1,
                TapName = "Dale's Pale Ale",
                OnTap = true,
                Name = "Pumpkin Ale",
                BrewDate = new DateTime(2013, 9, 28)
            });
            db.Beers.AddOrUpdate(new Beer { BeerId = 4, StyleId = 3, LocationId = 2, BreweryId = 1, Name = "Tremens", BrewDate = new DateTime(2013, 9, 28) });

            #endregion

            #endregion
        }
    }
}
