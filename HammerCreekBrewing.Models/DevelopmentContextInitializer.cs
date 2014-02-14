
using HammerCreekBrewing.Data.Models;
using System;
using System.Data.Entity; 
using System.Linq;
using System.Web.Security;
using WebMatrix.WebData;
using BeerEnums = HammerCreekBrewing.Data.Enums;


namespace HammerCreekBrewing.Data
{
    public class DevelopmentContextInitializer : DropCreateDatabaseAlways<HCBContext>
    {
        protected override void Seed(HCBContext db)
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

            #region Data initialization

            #region Breweries
            db.Breweries.Add(new Brewery { BreweryId = 1, Name = "Hammer Creek Brewing" });
            db.SaveChanges();
            db.Breweries.Add(new Brewery { BreweryId = 2, Name = "Delirium" });
            db.SaveChanges();
            #endregion

            #region Locations

            db.Locations.Add(new Location { LocationId = 1, Name = "Basement" });
            db.SaveChanges();
            db.Locations.Add(new Location { LocationId = 2, Name = "Garage" });
            db.SaveChanges();
            db.Locations.Add(new Location { LocationId = 3, Name = "Storage" });

            #endregion

            #region BeerStyles

            db.BeerStyles.Add(new BeerStyle { BeerStyleId = (int)BeerEnums.BeerStyle.Witbier, StyleName = "Witbier" });
            db.SaveChanges();
            db.BeerStyles.Add(new BeerStyle { BeerStyleId = (int)BeerEnums.BeerStyle.Stout, StyleName = "Stout" });
            db.SaveChanges();
            db.BeerStyles.Add(new BeerStyle { BeerStyleId = (int)BeerEnums.BeerStyle.PaleAle, StyleName = "Pale Ale" });
            db.SaveChanges();
            db.BeerStyles.Add(new BeerStyle { BeerStyleId = (int)BeerEnums.BeerStyle.BelgiumTripple, StyleName = "Belgium Tripple" });
            db.SaveChanges();
            db.BeerStyles.Add(new BeerStyle { BeerStyleId = (int)BeerEnums.BeerStyle.BelgiumStrongPaleAle, StyleName = "Belgium Strong Pale Ale" });
            db.SaveChanges();

            #endregion

            #region Beers


            db.Beers.Add(new Beer { BeerId = 1, StyleId = (int)BeerEnums.BeerStyle.Witbier, LocationId = 2, BreweryId = 1, Name = "Peach On Wit", BrewDate = new DateTime(2013, 9, 28) });
            db.SaveChanges();
            db.Beers.Add(new Beer { BeerId = 2, StyleId = (int)BeerEnums.BeerStyle.Stout, LocationId = 2, BreweryId = 1, Name = "Milk Stout", BrewDate = new DateTime(2013, 9, 28) });
            db.SaveChanges();
            db.Beers.Add(new Beer { BeerId = 3, StyleId = (int)BeerEnums.BeerStyle.PaleAle, LocationId = 1, BreweryId = 1, TapName = "Dale's Pale Ale", OnTap = true, Name = "Pumpkin Ale", BrewDate = new DateTime(2013, 9, 28) });
            db.SaveChanges();
            db.Beers.Add(new Beer { BeerId = 4, StyleId = (int)BeerEnums.BeerStyle.BelgiumStrongPaleAle, LocationId = 2, BreweryId = 1, Name = "Tremens", BrewDate = new DateTime(2013, 9, 28) });
            db.SaveChanges();

            #endregion

            #endregion
        }
    }
}
