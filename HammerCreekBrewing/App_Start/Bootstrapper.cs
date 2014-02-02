using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Microsoft.AspNet.Identity;
using HammerCreekBrewing.Mappings;
using HammerCreekBrewing.Environment;
using HammerCreekBrewing.Framework.Mvc;
using HammerCreekBrewing.Data;
using WebMatrix.WebData;
using System.Data.Entity;
using AutoMapper;
using AutoMapper.Mappers;

namespace HammerCreekBrewing
{
    public static class Bootstrapper
    {
        private static string _dbconn;

        //private IContainer _container;
        public static void Run(string dbConnection)
        {
            _dbconn = dbConnection;
            // Initilize mapping Profiles
            AutoMapperConfiguration.Configure();
            SetAutofacContainer(); 
        }
        private static void SetAutofacContainer()
        {
           // Database.SetInitializer(new DevelopmentContextInitializer());
            var db = new HCBContext(_dbconn);
            db.Database.Initialize(true);
            //if (!WebSecurity.Initialized)
            //    WebSecurity.InitializeDatabaseConnection("HammerCreekBrewingContext",
            //                                             "UserProfile", "UserId", "UserName", autoCreateTables: true);

            // new container
            var builder = new ContainerBuilder();
            builder.RegisterModule(new HCBModule(db));
            var _container = builder.Build();


            // initialize controller factory
            var controllerFactory = new ControllerFactory(_container);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(_container));
        }
    }
}