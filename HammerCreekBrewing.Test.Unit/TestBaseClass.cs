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
        public static HCBContext db;
        
        [SetUp]
        public void RunBeforeAnyTests()
        {
            //db = new HCBContext(Connection); 
            //db.Database.Initialize(true);
            Bootstrapper.Run(Connection);

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
            db.Database.Delete();
            //db.Dispose();
        }              

    }
}
