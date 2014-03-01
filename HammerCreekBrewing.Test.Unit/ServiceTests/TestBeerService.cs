using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using FakeItEasy;
using System.Threading.Tasks;
using NUnit.Framework;
using HammerCreekBrewing.Services;
using HammerCreekBrewing.Data.ViewModels;
using HammerCreekBrewing.Data.Enums;

namespace HammerCreekBrewing.Test.Unit.ServiceTests
{
    [TestFixture]
    public class TestBeerService : TestBaseClass
    {
        [Test]
        public async void TestGetBeer()
        {
            //using (var cScope = Container.BeginLifetimeScope())
            //{ 
            //get a beer should return beer with id = 1  see DevelopmentContextInitializer seed definition in context configuration
                //also testing automapper
                var beerMenuVM = await BeerService.GetBeerAsync<BeerMenuViewModel>(1);
                Assert.AreEqual(Peach.Id, beerMenuVM.Id);
                Assert.AreEqual(Peach.StyleId, beerMenuVM.StyleId);
                Assert.AreEqual(Peach.StyleName, beerMenuVM.StyleName);
                Assert.AreEqual(Peach.Name, beerMenuVM.Name);
                Assert.AreEqual(Peach.BreweryName, beerMenuVM.BreweryName);
                Assert.AreEqual(Peach.BrewDate, beerMenuVM.BrewDate);
                Assert.AreEqual(Peach.TapName, beerMenuVM.TapName);
           //
        }
        [Test]
        public async void TestGetTappedBeerInside()
        { 
                var beerOnTap = await BeerService.GetBeerOnTapInside<BeerMenuViewModel>();
                Assert.AreEqual(1, beerOnTap.Count());
                var firstBeer = beerOnTap.FirstOrDefault();
                Assert.AreEqual(PumpkinAle.Id, firstBeer.Id);
                Assert.AreEqual(PumpkinAle.StyleId, firstBeer.StyleId);
                Assert.AreEqual(PumpkinAle.StyleName, firstBeer.StyleName);
                Assert.AreEqual(PumpkinAle.Name, firstBeer.Name);
                Assert.AreEqual(PumpkinAle.BreweryName, firstBeer.BreweryName);
                Assert.AreEqual(PumpkinAle.BrewDate, firstBeer.BrewDate);
                Assert.AreEqual(PumpkinAle.TapName, firstBeer.TapName);
            

        }
        [Test]
        public async void TestGetTappedBeerGarage()
        {
            var beerOnTap = await BeerService.GetBeerOnTapGarage<BeerMenuViewModel>();
            Assert.AreEqual(1, beerOnTap.Count());
            var firstBeer = beerOnTap.FirstOrDefault();
            Assert.AreEqual(Peach.Id, firstBeer.Id);
            Assert.AreEqual(Peach.StyleId, firstBeer.StyleId);
            Assert.AreEqual(Peach.StyleName, firstBeer.StyleName);
            Assert.AreEqual(Peach.Name, firstBeer.Name);
            Assert.AreEqual(Peach.BreweryName, firstBeer.BreweryName);
            Assert.AreEqual(Peach.BrewDate, firstBeer.BrewDate);
            Assert.AreEqual(Peach.TapName, firstBeer.TapName);


        }
        [Test]
        public async void TestGetBeerInFridge()
        {
            var beerInFridge = await BeerService.GetBeerInFridge<BeerMenuViewModel>();
            Assert.AreEqual(1, beerInFridge.Count());
            var firstBeer = beerInFridge.FirstOrDefault();
            Assert.AreEqual(Tremens.Id, firstBeer.Id);
            Assert.AreEqual(Tremens.StyleId, firstBeer.StyleId);
            Assert.AreEqual(Tremens.StyleName, firstBeer.StyleName);
            Assert.AreEqual(Tremens.Name, firstBeer.Name);
            Assert.AreEqual(Tremens.BreweryName, firstBeer.BreweryName);
            Assert.AreEqual(Tremens.BrewDate, firstBeer.BrewDate);
            Assert.AreEqual(Tremens.TapName, firstBeer.TapName);
            Assert.AreEqual(Tremens.Abv, firstBeer.Abv);


        }

        [Test]
        public async void TestGetAllBeer()
        {
            var allBeer = await BeerService.GetAllBeersAsync<BeerMenuViewModel>();
            var eqCom = new BeerVMEqualityComparer();
            Assert.AreEqual(3, allBeer.Count());
            Assert.True(allBeer.Contains<BeerMenuViewModel>(Peach, eqCom));
            Assert.True(allBeer.Contains<BeerMenuViewModel>(Tremens, eqCom));
            Assert.True(allBeer.Contains<BeerMenuViewModel>(PumpkinAle, eqCom)); 
        }
         
    }
    public class BeerVMEqualityComparer : IEqualityComparer<BeerMenuViewModel>
    {

        public  bool Equals(BeerMenuViewModel b1, BeerMenuViewModel b2)
        {
            if (b1.Abv == b2.Abv
                & b1.BrewDate == b2.BrewDate
                & b1.BreweryName == b2.BreweryName
                & b1.KeggedDate == b2.KeggedDate
                & b1.KegId == b2.KegId
                & b1.LocationName == b2.LocationName
                & b1.Name == b2.Name
                & b1.StyleId == b2.StyleId
                & b1.StyleName == b2.StyleName
                & b1.TapName == b2.TapName
                & b1.TappedDate == b2.TappedDate
                & b1.Id == b2.Id)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int GetHashCode(BeerMenuViewModel beer){
            return beer.Id;
        }

    }
}
