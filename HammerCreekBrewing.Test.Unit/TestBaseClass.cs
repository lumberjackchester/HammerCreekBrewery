using System;
using NUnit.Framework;
using System.Data.Entity;
using FakeItEasy; 
using System.Web.Mvc;
using Autofac;
using HammerCreekBrewing.Data;
using HammerCreekBrewing.Framework.Mvc;
using HammerCreekBrewing.Environment;

namespace HammerCreekBrewing.Test.Unit
{
    [SetUpFixture]
    public class TestBaseClass
    {
        public static IContainer Container { get; set; }
        public static readonly string Connection = "name=HammerCreekBrewingContext.Test";
        public static HCBContext _db;

        
        [SetUp]
        public void RunBeforeAnyTests()
        { 
            AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Directory.GetCurrentDirectory());



            Database.SetInitializer<HCBContext>(new DevelopmentContextInitializer());
            _db = new HCBContext(Connection);
            _db.Database.Delete();
            _db.Database.Initialize(true);
            Container = Bootstrapper.Run(_db);

            ////// The connetion string for Testing 
            //var builder = new ContainerBuilder();
            //builder.RegisterModule(new HCBModule(db));
            //Container = builder.Build();

            // initialize controller factory
            //var controllerFactory = new ControllerFactory(Container);
            //ControllerBuilder.Current.SetControllerFactory(controllerFactory);

        }
        [TearDown]
        public void RunAfterAnyTests()
        {
           // _db.Database.Delete();
            //db.Dispose();
        }              

    }
}
