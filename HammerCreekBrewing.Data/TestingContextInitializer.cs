
using HammerCreekBrewing.Data.ViewModels;
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
            DataContextSeed.InitData(db);
        }
    }
}
