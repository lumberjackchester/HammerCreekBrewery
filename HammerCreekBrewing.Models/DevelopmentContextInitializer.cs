using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Security;
using WebMatrix.WebData;
using HammerCreekBrewing.Models;


namespace HammerCreekBrewing.Models
{
    public class DevelopmentContextInitializer : DropCreateDatabaseIfModelChanges<HCBContext>
    {
        protected override void Seed(HCBContext db)
        {
            WebSecurity.InitializeDatabaseConnection("DefaultConnection",
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
                #region BeerStyles

                 db.BeerStyles.Add(new BeerStyle { BeerStyleId = 1, StyleName = "WitBier" });
                 db.BeerStyles.Add(new BeerStyle { BeerStyleId = 2, StyleName = "Stout" });
                 db.BeerStyles.Add(new BeerStyle { BeerStyleId = 3, StyleName = "Ale" });

                #endregion  

                #region Beers


                 db.Beers.Add(new Beer { BeerId = 1, StyleId = 1, Name = "Peach On Wit", BrewDate = new DateTime(2013, 9, 28) });
                 db.Beers.Add(new Beer { BeerId = 2, StyleId = 3, OnTap = true, Name = "Pumpkin Ale", BrewDate = new DateTime(2013, 9, 28) });

            #endregion

            #endregion
        }
    }
}
