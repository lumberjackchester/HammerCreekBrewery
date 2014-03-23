
using HammerCreekBrewing.Data.Models;
using System;
using System.Data.Entity; 
using System.Linq;
using System.Web.Security;
using WebMatrix.WebData;
using BeerEnums = HammerCreekBrewing.Data.Enums;


namespace HammerCreekBrewing.Data
{
    public class TestingContextInitializer : DropCreateDatabaseAlways<HCBContext>
    {
        protected override void Seed(HCBContext db)
        {
            HammerCreekDataContextSeed.InitData(db);
        }
    }
}
