
using HammerCreekBrewing.Data.Models;
using System;
using System.Data.Entity; 
using System.Linq;
using System.Web.Security;
using WebMatrix.WebData;
using BeerEnums = HammerCreekBrewing.Data.Enums;


namespace HammerCreekBrewing.Data
{
    public class DevelopmentContextInitializer : DropCreateDatabaseIfModelChanges<HCBContext>
    {
        protected override void Seed(HCBContext db)
        {
            HammerCreekDataContextSeed.InitData(db);
        }
    }
    public class ProductionContextInitializer : CreateDatabaseIfNotExists<HCBContext>
    {
        protected override void Seed(HCBContext db)
        {
            HammerCreekDataContextSeed.InitData(db);
        }
    }
}
