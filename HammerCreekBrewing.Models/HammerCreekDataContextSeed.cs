using HammerCreekBrewing.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerEnums = HammerCreekBrewing.Data.Enums;

namespace HammerCreekBrewing.Data
{
    public class HammerCreekDataContextSeed
    {
        public static void InitData(HCBContext db)
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
            db.Breweries.Add(new Brewery { BreweryId = 2, Name = "Brouwerij Huyghe" });
            db.SaveChanges();
            db.Breweries.Add(new Brewery { BreweryId = 3, Name = "Cigar City" });
            db.SaveChanges();
            #endregion

            #region Locations

            db.Locations.Add(new Location { LocationId = 1, Name = "Basement" });
            db.SaveChanges();
            db.Locations.Add(new Location { LocationId = 2, Name = "Garage" });
            db.SaveChanges();
            db.Locations.Add(new Location { LocationId = 3, Name = "Fridge" });
            db.SaveChanges();
            db.Locations.Add(new Location { LocationId = 4, Name = "Storage" });

            #endregion

            #region BeerStyles

            db.BeerStyles.Add(new BeerStyle { BeerStyleId = 1, StyleName = "Witbier" });
            db.SaveChanges();
            db.BeerStyles.Add(new BeerStyle { BeerStyleId = 2, StyleName = "Stout" });
            db.SaveChanges();
            db.BeerStyles.Add(new BeerStyle { BeerStyleId = 3, StyleName = "Pale Ale" });
            db.SaveChanges();
            db.BeerStyles.Add(new BeerStyle { BeerStyleId = 4, StyleName = "Belgium Tripple" });
            db.SaveChanges();
            db.BeerStyles.Add(new BeerStyle { BeerStyleId = 5, StyleName = "Belgium Strong Pale Ale" });
            db.SaveChanges();
            db.BeerStyles.Add(new BeerStyle { BeerStyleId = 6, StyleName = "IPA" });
            db.SaveChanges();
            db.BeerStyles.Add(new BeerStyle { BeerStyleId = 7, StyleName = "ESB" });
            db.SaveChanges();
            //db.BeerStyles.Add(new BeerStyle { BeerStyleId = 5, StyleName = "Belgium Strong Pale Ale" });
            //db.SaveChanges();

            #endregion

            #region Beers


            db.Beers.Add(new Beer
            {
                BeerId = 1,
                StyleId = 6,
                LocationId = (int)BeerEnums.Locations.Garage,
                BreweryId = 3,
                TapName = "Left Tap - Left Handle",
                OnTap = true,
                Name = "Jai Alai",
                BrewDate = new DateTime(2013, 9, 28)
            });
            db.SaveChanges();
            db.Beers.Add(new Beer
            {
                BeerId = 2,
                StyleId = 6,
                LocationId = (int)BeerEnums.Locations.Garage,
                BreweryId = 1,
                TapName = "Right Tap - Center Handle",
                OnTap = true,
                Name = "Pliny Clone",
                BrewDate = new DateTime(2013, 9, 28)
            });
            db.SaveChanges();
            db.Beers.Add(new Beer
            {
                BeerId = 3,
                StyleId = 7,
                LocationId = (int)BeerEnums.Locations.Basement,
                BreweryId = 1,
                Name = "Hammer Creeek Brewing ESB",
                TapName = "Right Handle",               
                BrewDate = new DateTime(2013, 9, 28)
            });
            db.SaveChanges();
           
            #endregion

            #endregion
        }
    }
}
