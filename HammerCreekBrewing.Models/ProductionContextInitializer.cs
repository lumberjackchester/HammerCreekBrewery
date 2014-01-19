using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Security;
using WebMatrix.WebData;

namespace HammerCreekBrewing.Data {
    public class ProductionContextInitializer : CreateDatabaseIfNotExists<HCBContext> {
        protected override void Seed(HCBContext db) {
            WebSecurity.InitializeDatabaseConnection("HammerCreekBrewingContext",
                "UserProfile", "UserId", "UserName", autoCreateTables: true);
            var roles = (SimpleRoleProvider)Roles.Provider;
            var membership = (SimpleMembershipProvider)Membership.Provider;

            if (!roles.RoleExists("Admin")) {
                roles.CreateRole("Admin");
            }
            if (membership.GetUser("Administrator", false) == null) {
                membership.CreateUserAndAccount("Administrator", "Password#1");
            }
            if (!roles.GetRolesForUser("Administrator").Contains("Admin")) {
                roles.AddUsersToRoles(new[] { "Administrator" }, new[] { "Admin" });
            }
        }
    }
}
