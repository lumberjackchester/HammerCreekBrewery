using System;
using NUnit.Framework;
using System.Data.Entity;
using FakeItEasy; 
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.WebApi;
using HammerCreekBrewing.Data;
using HammerCreekBrewing.Framework.Mvc;
using HammerCreekBrewing.Environment;
using HammerCreekBrewing.Services;
using HammerCreekBrewing.Data.ViewModels;
using HammerCreekBrewing.Data.Enums;
using System.Collections.Generic;

namespace HammerCreekBrewing.Test.Unit
{
    [SetUpFixture]
    public class TestBaseClass
    {
        public static IContainer Container { get; set; }
        public static readonly string Connection = "name=HammerCreekBrewingContext.Test";
        public static HCBContext _db;
        public IBeerService TestBeerService;

        public BeerMenuViewModel PumpkinAle;
        public BeerMenuViewModel Tremens;
        public BeerMenuViewModel Peach;

        public BeerVMEqualityComparer BeerEqualComparer = new HammerCreekBrewing.Test.Unit.BeerVMEqualityComparer();
        [SetUp]
        public void RunBeforeAnyTests()
        { 
            AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Directory.GetCurrentDirectory());



            Database.SetInitializer<HCBContext>(new DevelopmentContextInitializer());
            _db = new HCBContext(Connection);
            _db.Database.Delete();
            _db.Database.Initialize(true);
            Container = Bootstrapper.TestRun(Connection);

            Assert.IsNotNull(Container);

            var lifetimeScope = Container.BeginLifetimeScope(AutofacWebApiDependencyResolver.ApiRequestTag);
            var dependencyScope = new AutofacWebApiDependencyScope(lifetimeScope);

            TestBeerService = dependencyScope.GetService(typeof(IBeerService)) as BeerService;

          //TestBeerService = Container.Resolve<IBeerService>();
            //TestBeerService = A.Fake<IBeerService>();
            Assert.IsNotNull(TestBeerService);
            SetStaticBeerVMs(); 

        }

        private void SetStaticBeerVMs(){

            PumpkinAle = new BeerMenuViewModel
            {
                Id = 2,
                StyleId = (int)HammerCreekBrewing.Data.Enums.BeerStyle.PaleAle,
                StyleName = "Pale Ale",
                BreweryName = "Hammer Creek Brewing",
                TapName = "Dale's Pale Ale",
                Name = "Pumpkin Ale",
                BrewDate = new DateTime(2013, 9, 28).ToString("dd MMM yyyy"),
                KeggedDate = "N/A",
                TappedDate = "N/A"
            };

           Tremens = new BeerMenuViewModel
           {
               Id = 3,
               StyleId = (int)HammerCreekBrewing.Data.Enums.BeerStyle.BelgiumStrongPaleAle,
               StyleName = "Belgium Strong Pale Ale",
               BreweryName = "Brouwerij Huyghe",
               Name = "Delirium Tremens",
               Abv = "8.5%",
               BrewDate = new DateTime(2013, 9, 28).ToString("dd MMM yyyy"),
               KeggedDate = "N/A",
               TappedDate = "N/A"
           };
           Peach = new BeerMenuViewModel
           {
               Id = 1,
               StyleId = (int)HammerCreekBrewing.Data.Enums.BeerStyle.Witbier,
               StyleName = "Witbier",
               BreweryName = "Hammer Creek Brewing",
               TapName = "Moose Drool",
               Name = "Peach On Wit",
               BrewDate = new DateTime(2013, 9, 28).ToString("dd MMM yyyy"),
               KeggedDate = "N/A",
               TappedDate = "N/A"
           };
        }

        public HammerCreekBrewing.Controllers.BeerMenuController GetBeerMenuAPI()
        {
            var fakeLogging = A.Fake<ILogging>();
            var bmApi = new HammerCreekBrewing.Controllers.BeerMenuController(TestBeerService, fakeLogging);
            return bmApi;
        }

        [TearDown]
        public void RunAfterAnyTests()
        {
          
        }

    }

    
        public class BeerVMEqualityComparer : IEqualityComparer<BeerMenuViewModel>
        {

            public bool Equals(BeerMenuViewModel dbBeer, BeerMenuViewModel testBaseBeer)
            {
                if (testBaseBeer.Abv == dbBeer.Abv
                    & testBaseBeer.BrewDate == dbBeer.BrewDate
                    & testBaseBeer.BreweryName == dbBeer.BreweryName
                    & testBaseBeer.KeggedDate == dbBeer.KeggedDate
                    & testBaseBeer.KegId == dbBeer.KegId
                    & testBaseBeer.LocationName == dbBeer.LocationName
                    & testBaseBeer.Name == dbBeer.Name
                    & testBaseBeer.StyleId == dbBeer.StyleId
                    & testBaseBeer.StyleName == dbBeer.StyleName
                    & testBaseBeer.TapName == dbBeer.TapName
                    & testBaseBeer.TappedDate == dbBeer.TappedDate
                    & testBaseBeer.Id == dbBeer.Id)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public int GetHashCode(BeerMenuViewModel beer)
            {
                return beer.Id;
            }

        }

}
