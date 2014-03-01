using System;
using NUnit.Framework;
using System.Data.Entity;
using FakeItEasy; 
using System.Web.Mvc;
using Autofac;
using HammerCreekBrewing.Data;
using HammerCreekBrewing.Framework.Mvc;
using HammerCreekBrewing.Environment;
using HammerCreekBrewing.Services;
using HammerCreekBrewing.Data.ViewModels;
using HammerCreekBrewing.Data.Enums;

namespace HammerCreekBrewing.Test.Unit
{
    [SetUpFixture]
    public class TestBaseClass
    {
        public static IContainer Container { get; set; }
        public static readonly string Connection = "name=HammerCreekBrewingContext.Test";
        public static HCBContext _db;
        public IBeerService BeerService;

        public BeerMenuViewModel PumpkinAle;
        public BeerMenuViewModel Tremens;
        public BeerMenuViewModel Peach;

        [SetUp]
        public void RunBeforeAnyTests()
        { 
            AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Directory.GetCurrentDirectory());



            Database.SetInitializer<HCBContext>(new DevelopmentContextInitializer());
            _db = new HCBContext(Connection);
            _db.Database.Delete();
            _db.Database.Initialize(true);
            Container = Bootstrapper.Run(_db);

            Assert.IsNotNull(Container);
            BeerService = Container.Resolve<IBeerService>();

            Assert.IsNotNull(BeerService);
            SetStaticBeerVMs();
            ////// The connetion string for Testing 
            //var builder = new ContainerBuilder();
            //builder.RegisterModule(new HCBModule(db));
            //Container = builder.Build();

            // initialize controller factory
            //var controllerFactory = new ControllerFactory(Container);
            //ControllerBuilder.Current.SetControllerFactory(controllerFactory);

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

        [TearDown]
        public void RunAfterAnyTests()
        {
            if (_db != null)
            {
                if (_db.Database.Exists())
                {
                    _db.Database.Delete();
                    _db.Dispose();
                }
            }
        }              

    }
}
