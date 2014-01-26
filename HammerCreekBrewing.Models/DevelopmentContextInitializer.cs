using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Security;
using WebMatrix.WebData;
using HammerCreekBrewing.Data.Models;


namespace HammerCreekBrewing.Data
{
    public class DevelopmentContextInitializer : DropCreateDatabaseIfModelChanges<HCBContext>
    {
        protected override void Seed(HCBContext db)
        {
            WebSecurity.InitializeDatabaseConnection("HammerCreekBrewingContext",
                "UserProfile", "UserId", "UserName", autoCreateTables: true);
            var roles = (SimpleRoleProvider)Roles.Provider;
            var membership = (SimpleMembershipProvider)Membership.Provider;

            if (!roles.RoleExists("Admin"))
            {
                roles.CreateRole("Admin");
            }
            if (membership.GetUser("Administrator", false) == null)
            {
                membership.CreateUserAndAccount("Administrator", "AR15#22");
            }
            if (!roles.GetRolesForUser("Administrator").Contains("Admin"))
            {
                roles.AddUsersToRoles(new[] { "Administrator" }, new[] { "Admin" });
            }

            // Database data initialization -- needs expanding upon.
            #region Data initialization

            #region Breweries
            db.Breweries.Add(new Brewery{BreweryId =1, Name = "Hammer Creek Brewing"});
            db.Breweries.Add(new Brewery { BreweryId = 2, Name = "Delirium" });
            #endregion

            #region Locations

            db.Locations.Add(new Location { LocationId = 1, Name = "Basement" });
            db.Locations.Add(new Location { LocationId = 2, Name = "Garage" });
            db.Locations.Add(new Location { LocationId = 3, Name = "Storage" });
            
            #endregion

            #region BeerStyles

            db.BeerStyles.Add(new BeerStyle { BeerStyleId = 1, StyleName = "WitBier"});
            db.BeerStyles.Add(new BeerStyle { BeerStyleId = 2, StyleName = "Stout" });
            db.BeerStyles.Add(new BeerStyle { BeerStyleId = 3, StyleName = "Ale" });
            db.BeerStyles.Add(new BeerStyle { BeerStyleId = 4, StyleName = "Belgium" });

            #endregion 

            #region Beers


            db.Beers.Add(new Beer { BeerId = 1, StyleId = 1, LocationId = 2, BreweryId = 1, Name = "Peach On Wit", BrewDate = new DateTime(2013, 9, 28) });
            db.Beers.Add(new Beer { BeerId = 2, StyleId = 2, LocationId = 2, BreweryId = 1, Name = "Milk Stout", BrewDate = new DateTime(2013, 9, 28) });
            db.Beers.Add(new Beer { BeerId = 3, StyleId = 3, LocationId = 1, BreweryId = 1, TapName = "Dale's Pale Ale",
                                    OnTap = true, Name = "Pumpkin Ale", BrewDate = new DateTime(2013, 9, 28) });
            db.Beers.Add(new Beer { BeerId = 4, StyleId = 3, LocationId = 2, BreweryId = 1, Name = "Tremens", BrewDate = new DateTime(2013, 9, 28) });

            #endregion

            #endregion
        }
    }
}
