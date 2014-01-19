using System;
using System.Web;
using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HammerCreekBrewing.Data;
using HammerCreekBrewing.Services;


namespace HammerCreekBrewing.Test.Unit.ContollerTests
{
    [TestClass]
    public class TestBeerController : TestBaseClass
    {
        [TestMethod]
        public void TestGetBeer()
        {
            using (var cScope = Container.BeginLifetimeScope())
            {

                IUnitOfWork uow = cScope.Resolve<IUnitOfWork>();

                //var beerServ = new BeerService(uow); 
                //var vm = new DepartmentUpdateViewModel
                //{
                //    Id = 1,
                //    PhotoUrl = "2222",
                //    WhatWeDo = "we do stuff",
                //    FunFact = "I like cake"
                //};

                //var dapi = new DepartmentApiController(uow, profileService, departmentService, postService, weatherService);
                //dapi.UpdateDepartment(vm);





            }
        }
    }
}
