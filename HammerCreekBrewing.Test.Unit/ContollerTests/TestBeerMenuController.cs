using System;
using System.Web;
using Autofac;
using NUnit.Framework;
using HammerCreekBrewing.Data.ViewModels;
using HammerCreekBrewing.Services;
using HammerCreekBrewing;
using FakeItEasy;
using System.Linq;
using System.Web.Http.Results;

namespace HammerCreekBrewing.Test.Unit.ContollerTests
{
    [TestFixture]
    public class TestBeerMenuController : TestBaseClass
    {
        [Test]
        public void TestGetBeerMenu()
        {
            var bmAPi = GetBeerMenuAPI();

            var beerHomeVM =  bmAPi.GetBeerMenu().Result as OkNegotiatedContentResult<HomeViewModel>;              
            Assert.IsNotNull(beerHomeVM);
            Assert.IsNotNull(beerHomeVM.Content);

            Assert.IsNotNull(beerHomeVM.Content.AllBeer);
            Assert.AreEqual(3, beerHomeVM.Content.AllBeer.Count);
            Assert.True(beerHomeVM.Content.AllBeer.Contains<BeerMenuViewModel>(Peach, BeerEqualComparer));
            Assert.True(beerHomeVM.Content.AllBeer.Contains<BeerMenuViewModel>(Tremens, BeerEqualComparer));
            Assert.True(beerHomeVM.Content.AllBeer.Contains<BeerMenuViewModel>(PumpkinAle, BeerEqualComparer)); 
             
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
    }
}
