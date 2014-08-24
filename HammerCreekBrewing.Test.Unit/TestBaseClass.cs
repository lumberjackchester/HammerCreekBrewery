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

        public BeerViewModel Pliny;
        public BeerViewModel ESB;
        public BeerViewModel JaiAlai;
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

            JaiAlai = new BeerViewModel
            {
                Id = 1,
                StyleId = 6,
                StyleName = "IPA",
                BreweryName = "Cigar City",
                TapName = "Left Tap - Left Handle",
                Name = "Jai Alai",
                BrewDate = new DateTime(2013, 9, 28).ToString("dd MMM yyyy"),
                KeggedDate = "N/A",
                TappedDate = "N/A",
                LocationName = "Garage"
                //BeerId = 1,
                //StyleId = 6,
                //LocationId = (int)BeerEnums.Locations.Garage,
                //BreweryId = 3,
                //TapName = "Left Tap - Left Handle",
                //OnTap = true,
                //Name = "Jai Alai",
                //BrewDate = new DateTime(2013, 9, 28)
            };
            Pliny = new BeerViewModel
            {
                Id = 2,
                StyleId = 6,
                StyleName = "IPA",
                BreweryName = "Hammer Creek Brewing",
                TapName = "Right Tap - Center Handle",
                Name = "Pliny Clone",
                BrewDate = new DateTime(2013, 9, 28).ToString("dd MMM yyyy"),
                KeggedDate = "N/A",
                TappedDate = "N/A",
                LocationName = "Garage"

                //  BeerId = 2,
                //StyleId = 6,
                //LocationId = (int)BeerEnums.Locations.Garage,
                //BreweryId = 1,
                //TapName = "Right Tap - Center Handle",
                //OnTap = true,
                //Name = "Pliny Clone",
                //BrewDate = new DateTime(2013, 9, 28)

            };

           ESB = new BeerViewModel
           {
               Id = 3,
               StyleId = 7,
               StyleName = "ESB",
               BreweryName = "Hammer Creek Brewing",
               TapName = "Right Handle",   
               Name = "Hammer Creek Brewing ESB",
               BrewDate = new DateTime(2013, 9, 28).ToString("dd MMM yyyy"),
               KeggedDate = "N/A",
               TappedDate = "N/A",
                LocationName = "Basement"

                //BeerId = 3,
                //StyleId = 7,
                //LocationId = (int)BeerEnums.Locations.Basement,
                //BreweryId = 1,
                //Name = "Hammer Creek Brewing ESB",
                //TapName = "Right Handle",               
                //BrewDate = new DateTime(2013, 9, 28)
           };
           //MilkStout = new BeerViewModel
           //{
           //    Id = 4,
           //    StyleId = 4,
           //    StyleName = "Stout",
           //    BreweryName = "Hammer Creek Brewing", 
           //    Name = "Milk Stout",
           //    BrewDate = new DateTime(2013, 9, 28).ToString("dd MMM yyyy"),
           //    KeggedDate = "N/A",
           //    TappedDate = "N/A",
           //    LocationName = "Storage"
           //};
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
                if (testBaseBeer.Abv == dbBeer.Abv)
                {
                    if (testBaseBeer.BrewDate == dbBeer.BrewDate)
                    {
                        if (testBaseBeer.BreweryName == dbBeer.BreweryName)
                        {
                            if (testBaseBeer.KeggedDate == dbBeer.KeggedDate)
                            {
                                if (testBaseBeer.KegId == dbBeer.KegId)
                                {

                                    if (testBaseBeer.LocationName == dbBeer.LocationName)
                                    {
                                        if (testBaseBeer.Name == dbBeer.Name)
                                        {
                                            if (testBaseBeer.StyleId == dbBeer.StyleId)
                                            {
                                                if (testBaseBeer.StyleName == dbBeer.StyleName)
                                                {
                                                    if (testBaseBeer.TapName == dbBeer.TapName)
                                                    {
                                                        if (testBaseBeer.TappedDate == dbBeer.TappedDate)
                                                        {
                                                            if (testBaseBeer.Id == dbBeer.Id)
                                                            {

                                                                return true;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                return false;
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
