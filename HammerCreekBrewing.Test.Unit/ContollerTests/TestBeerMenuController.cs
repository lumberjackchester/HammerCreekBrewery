using System;
using System.Web;
using Autofac;
using NUnit.Framework;
using HammerCreekBrewing.Data.ViewModels;
using HammerCreekBrewing.Services;
using HammerCreekBrewing;
using FakeItEasy;
using System.Linq;

namespace HammerCreekBrewing.Test.Unit.ContollerTests
{
    [TestFixture]
    public class TestBeerMenuController : TestBaseClass
    {
       
        public void TestHomeVMIsNotNull()
        {

            Assert.IsNotNull(HomeView);
            Assert.IsNotNull(HomeView.Content);
        }
        [Test]
        public void TestGetBeerMenu()
        {
            TestHomeVMIsNotNull();
            Assert.IsNotNull(HomeView.Content.AllBeer);
            Assert.AreEqual(3, HomeView.Content.AllBeer.Count);
            Assert.True(HomeView.Content.AllBeer.Contains<BeerViewModel>(JaiAlai, BeerEqualComparer));
            Assert.True(HomeView.Content.AllBeer.Contains<BeerViewModel>(ESB, BeerEqualComparer));
            Assert.True(HomeView.Content.AllBeer.Contains<BeerViewModel>(Pliny, BeerEqualComparer)); 
          //  Assert.True(HomeView.Content.AllBeer.Contains<BeerViewModel>(MilkStout, BeerEqualComparer)); 
             
            //Assert.IsNotNull(beerHomeVM.Content.BeerInFridge);
            //Assert.IsNotNull(beerHomeVM.Content.BeerOnTapInside);
            //Assert.IsNotNull(beerHomeVM.Content.BeerOnTapGarage);

           //Assert.AreEqual(1, beerHomeVM.Content.BeerInFridge.Count);
           //Assert.AreEqual(1, beerHomeVM.Content.BeerOnTapInside.Count);
           //Assert.AreEqual(1, beerHomeVM.Content.BeerOnTapGarage.Count); 

           //Assert.True(beerHomeVM.Content.BeerOnTapGarage.Contains<BeerMenuViewModel>(Peach, BeerEqualComparer));
           //Assert.True(beerHomeVM.Content.BeerInFridge.Contains<BeerMenuViewModel>(Tremens, BeerEqualComparer));
           //Assert.True(beerHomeVM.Content.BeerOnTapInside.Contains<BeerMenuViewModel>(PumpkinAle, BeerEqualComparer)); 

          





            //Assert.AreEqual<string>(person.Name, negotiatedResult.Content.Name);
             
             
            //// --------------------------------------------------------

            ////successful update of person information and its verification
            //Person person = new Person();
            //person.Id = 10;
            //person.Name = "John updated";

            //IHttpActionResult result = people.PutPerson(10, person).Result;

            //StatusCodeResult statusCodeResult = result as StatusCodeResult;

            //Assert.IsNotNull(statusCodeResult);
            //Assert.AreEqual<HttpStatusCode>(HttpStatusCode.NoContent, statusCodeResult.StatusCode);

             
        }
        [Test]
        public void TestBeerLocations()
        {
            TestHomeVMIsNotNull();
            Assert.IsNotNull(HomeView.Content.AllLocations);
            Assert.AreEqual(4, HomeView.Content.AllLocations.Count);
            Assert.True(HomeView.Content.AllLocations.Contains<LocationViewModel>(Basement, LocationEqualComparer));
            Assert.True(HomeView.Content.AllLocations.Contains<LocationViewModel>(Garage, LocationEqualComparer));
            Assert.True(HomeView.Content.AllLocations.Contains<LocationViewModel>(Fridge, LocationEqualComparer));
            Assert.True(HomeView.Content.AllLocations.Contains<LocationViewModel>(Storage, LocationEqualComparer)); 
        }

    }
}
