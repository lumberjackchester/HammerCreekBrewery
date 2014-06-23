using System;
using HammerCreekBrewing.App_Start;
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
using HammerCreekBrewing.Controllers;
using System.Collections.Generic;
using System.IO;
using System.Web.Http.Results;

namespace HammerCreekBrewing.Test.Unit
{
    [SetUpFixture]
    public class TestBaseClass
    {
        public static IContainer Container { get; set; }
        public static readonly string Connection = "HammerCreekBrewingContext.Test";
        public static HCBContext _db;
        public IBeerService TestBeerService;

        public BeerViewModel PumpkinAle;
        public BeerViewModel Tremens;
        public BeerViewModel Peach;
        public BeerViewModel MilkStout;
        public LocationViewModel Basement = new LocationViewModel { Id = 1, Name = "Basement" };
        public LocationViewModel Garage = new LocationViewModel { Id = 2, Name = "Garage" };
        public LocationViewModel Fridge = new LocationViewModel { Id = 3, Name = "Fridge" };
        public LocationViewModel Storage = new LocationViewModel { Id = 4, Name = "Storage" };
        public OkNegotiatedContentResult<HomeViewModel> HomeView;

        public BeerMenuController BeerMenuAPi;

        public BeerVMEqualityComparer BeerEqualComparer = new BeerVMEqualityComparer();
        public LocationVMEqualityComparer LocationEqualComparer = new LocationVMEqualityComparer();

        [SetUp]
        public void RunBeforeAnyTests()
        { 
            AppDomain.CurrentDomain.SetData("DataDirectory", Directory.GetCurrentDirectory());

            if (_db == null)
            {
                DeleteDBIfExists();
            }
            Database.SetInitializer<HCBContext>(new TestingContextInitializer());
                _db = new HCBContext(Connection);
            
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
            SetHomeViewModelFromAPI();

        }

        private void SetStaticBeerVMs(){

            Peach = new BeerViewModel
            {
                Id = 1,
                StyleId = (int)HammerCreekBrewing.Data.Enums.BeerStyle.Witbier,
                StyleName = "Witbier",
                BreweryName = "Hammer Creek Brewing",
                TapName = "Moose Drool",
                Name = "Peach On Wit",
                BrewDate = new DateTime(2013, 9, 28).ToString("dd MMM yyyy"),
                KeggedDate = "N/A",
                TappedDate = "N/A",
                LocationName = "Garage"
            };
            PumpkinAle = new BeerViewModel
            {
                Id = 2,
                StyleId = (int)HammerCreekBrewing.Data.Enums.BeerStyle.PaleAle,
                StyleName = "Pale Ale",
                BreweryName = "Hammer Creek Brewing",
                TapName = "Dale's Pale Ale",
                Name = "Pumpkin Ale",
                BrewDate = new DateTime(2013, 9, 28).ToString("dd MMM yyyy"),
                KeggedDate = "N/A",
                TappedDate = "N/A",
                LocationName = "Basement"
            };

           Tremens = new BeerViewModel
           {
               Id = 3,
               StyleId = (int)HammerCreekBrewing.Data.Enums.BeerStyle.BelgiumStrongPaleAle,
               StyleName = "Belgium Strong Pale Ale",
               BreweryName = "Brouwerij Huyghe",
               Name = "Delirium Tremens",
               Abv = "8.5%",
               BrewDate = new DateTime(2013, 9, 28).ToString("dd MMM yyyy"),
               KeggedDate = "N/A",
               TappedDate = "N/A",
                LocationName = "Fridge"
           };
           MilkStout = new BeerViewModel
           {
               Id = 4,
               StyleId = (int)HammerCreekBrewing.Data.Enums.BeerStyle.Stout,
               StyleName = "Stout",
               BreweryName = "Hammer Creek Brewing", 
               Name = "Milk Stout",
               BrewDate = new DateTime(2013, 9, 28).ToString("dd MMM yyyy"),
               KeggedDate = "N/A",
               TappedDate = "N/A",
               LocationName = "Storage"
           };
        }

        public BeerMenuController GetBeerMenuAPI()
        {
            var fakeLogging = A.Fake<ILogging>();
            var bmApi = new HammerCreekBrewing.Controllers.BeerMenuController(TestBeerService, fakeLogging);
            return bmApi;
        }

        public void SetHomeViewModelFromAPI()
        {

            BeerMenuAPi = GetBeerMenuAPI();

            HomeView = BeerMenuAPi.GetBeerMenu() as OkNegotiatedContentResult<HomeViewModel>;   
        }

        private void DeleteDBIfExists()
        {
            if (_db != null)
            {
                _db.Dispose();
            }
            var dirToDB = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();
            var mdfName =Path.Combine(dirToDB, "HammerCreekBrewing.Test.mdf");
            var logName = Path.Combine(dirToDB, "HammerCreekBrewing.Test_log.ldf");
            if (File.Exists(mdfName))
            {
                File.Delete(mdfName);
            }
            if (File.Exists(logName))
            {
                File.Delete(logName);
            }
        }

        //[TearDown]
        //public void RunAfterAnyTests()
        //{
        //    DeleteDBIfExists();
        //}

    }

    
        public class BeerVMEqualityComparer : IEqualityComparer<BeerViewModel>
        {

            public bool Equals(BeerViewModel dbBeer, BeerViewModel testBaseBeer)
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
            public int GetHashCode(BeerViewModel beer)
            {
                return beer.Id;
            }

        }

        public class LocationVMEqualityComparer : IEqualityComparer<LocationViewModel>
        {

            public bool Equals(LocationViewModel dbLocation, LocationViewModel testBaseLocation)
            {
                if (testBaseLocation.Name == dbLocation.Name 
                    & testBaseLocation.Id == dbLocation.Id)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public int GetHashCode(LocationViewModel location)
            {
                return location.Id;
            }

        }

}
