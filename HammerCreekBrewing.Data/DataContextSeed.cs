using HammerCreekBrewing.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HammerCreekBrewing.Data.Enums;
using EnumStyle = HammerCreekBrewing.Data.Enums.BeerStyle;
using HammerCreekBrewing.Tools;

namespace HammerCreekBrewing.Data
{
    public class DataContextSeed
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

            db.BeerStyles.Add(new HammerCreekBrewing.Data.Entities.BeerStyle { BeerStyleId = (int)EnumStyle.Witbier, StyleName = "Witbier" });
            db.SaveChanges();
            db.BeerStyles.Add(new HammerCreekBrewing.Data.Entities.BeerStyle { BeerStyleId = (int)EnumStyle.Stout, StyleName = "Stout" });
            db.SaveChanges();
            db.BeerStyles.Add(new HammerCreekBrewing.Data.Entities.BeerStyle { BeerStyleId = (int)EnumStyle.PaleAle, StyleName = "Pale Ale" });
            db.SaveChanges();
            db.BeerStyles.Add(new HammerCreekBrewing.Data.Entities.BeerStyle { BeerStyleId = (int)EnumStyle.BelgiumTripple, StyleName = "Belgium Tripple" });
            db.SaveChanges();
            db.BeerStyles.Add(new HammerCreekBrewing.Data.Entities.BeerStyle { BeerStyleId = (int)EnumStyle.BelgiumStrongPaleAle, StyleName = "Belgium Strong Pale Ale" });
            db.SaveChanges();

            #endregion

            #region Beers


            db.Beers.Add(new Beer
            {
                BeerId = 1,
                StyleId = (int)EnumStyle.Witbier,
                LocationId = (int)Locations.Garage,
                BreweryId = 1,
                TapName = "Moose Drool",
                OnTap = true,
                Name = "Peach On Wit",
                BrewDate = new DateTime(2013, 9, 28)
            });
            db.SaveChanges();
            db.Beers.Add(new Beer
            {
                BeerId = 2,
                StyleId = (int)EnumStyle.PaleAle,
                LocationId = (int)Locations.Basement,
                BreweryId = 1,
                TapName = "Dale's Pale Ale",
                OnTap = true,
                Name = "Pumpkin Ale",
                BrewDate = new DateTime(2013, 9, 28)
            });
            db.SaveChanges();
            db.Beers.Add(new Beer
            {
                BeerId = 3,
                StyleId = (int)EnumStyle.BelgiumStrongPaleAle,
                LocationId = (int)Locations.Fridge,
                BreweryId = 2,
                Name = "Delirium Tremens",
                Abv = "8.5%",
                BrewDate = new DateTime(2013, 9, 28)
            });
            db.SaveChanges();
            db.Beers.Add(new Beer
            {
                BeerId = 4,
                StyleId = (int)EnumStyle.Stout,
                LocationId = (int)Locations.Storage,
                BreweryId = 1,
                Name = "Milk Stout",
                BrewDate = new DateTime(2013, 9, 28)
            });
            db.SaveChanges();

            #endregion

            #endregion
        }

        public static void InitData(AuthContext db)
        {
            db.Clients.AddRange(BuildClientsList());

        }
        private static List<Client> BuildClientsList()
        {

            List<Client> ClientsList = new List<Client> 
            {
                new Client
                { Id = "ngAuthApp", 
                    Secret= Helper.GetHash("abc@123"), 
                    Name="AngularJS front-end Application", 
                    ApplicationType =  ApplicationTypes.JavaScript, 
                    Active = true, 
                    RefreshTokenLifeTime = 7200, 
                    AllowedOrigin = "http://ngauthenticationweb.azurewebsites.net"
                },
                new Client
                { Id = "consoleApp", 
                    Secret=Helper.GetHash("123@abc"), 
                    Name="Console Application", 
                    ApplicationType = ApplicationTypes.NativeConfidential, 
                    Active = true, 
                    RefreshTokenLifeTime = 14400, 
                    AllowedOrigin = "*"
                }
            };

            return ClientsList;
        }
    }
}
