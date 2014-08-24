
using HammerCreekBrewing.Data.ViewModels;
using System;
using System.Data.Entity; 
using System.Linq;
using System.Web.Security;
using WebMatrix.WebData;
using BeerEnums = HammerCreekBrewing.Data.Enums;


namespace HammerCreekBrewing.Data
{
    public class DevelopmentHCBContextInitializer : DropCreateDatabaseIfModelChanges<HCBContext>
    {
        protected override void Seed(HCBContext db)
        {
            DataContextSeed.InitData(db);
        }
    }
    public class ProductionHCBContextInitializer : CreateDatabaseIfNotExists<HCBContext>
    {
        protected override void Seed(HCBContext db)
        {
            DataContextSeed.InitData(db);

            
        }
    }
    public class ProductionAuthContextInitializer : CreateDatabaseIfNotExists<AuthContext>
    {
        protected override void Seed(AuthContext db)
        {
           // DataContextSeed.InitData(db);


        }
    }
}
