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
            using (var cScope = Container.BeginLifetimeScope())
            {

                var beerService = cScope.Resolve<IBeerService>();

                //var beerServ = new BeerService(uow); 
                //var beerService = new BeerService();

                //get a beer should return beer with id = 1  see dbcontext seed definition in context configuration
                //also testing automapper
                var beerMenuVM = await beerService.GetBeerAsync<BeerMenuViewModel>(1);
                Assert.AreEqual(1, beerMenuVM.Id);
                Assert.AreEqual((int)BeerStyle.Witbier, beerMenuVM.StyleId);
                Assert.AreEqual("Witbier", beerMenuVM.StyleName);
                Assert.AreEqual("Peach On Wit", beerMenuVM.Name);
                Assert.AreEqual("Hammer Creek Brewing", beerMenuVM.BreweryName);
            }
        }
    }
}
