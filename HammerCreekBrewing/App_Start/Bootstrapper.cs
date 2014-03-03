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
        private static HCBContext _db;

        public static void Run(string dbConnection)
        {
            _dbconn = dbConnection;
            if (System.Configuration.ConfigurationManager.AppSettings["DatabaseContextInitializer"] == "DropAndRecreate")
                Database.SetInitializer<HCBContext>(new DevelopmentContextInitializer());

            _db = new HCBContext(_dbconn);
          //  _db.Database.Initialize(true);
            // Initilize mapping Profiles
            AutoMapperConfiguration.Configure();
            SetAutofacContainer(); 
        }
        public static IContainer Run(HCBContext db)
        {
            _db = db;
            // Initilize mapping Profiles
            AutoMapperConfiguration.Configure();
            return SetAutofacContainer();
        }
        private static IContainer SetAutofacContainer()
        {
            //if (!WebSecurity.Initialized)
            //    WebSecurity.InitializeDatabaseConnection("HammerCreekBrewingContext",
            //                                             "UserProfile", "UserId", "UserName", autoCreateTables: true);

            // new container
            var builder = new ContainerBuilder();
            builder.RegisterModule(new HCBModule(_db));
            var _container = builder.Build();


            // initialize controller factory
            var controllerFactory = new ControllerFactory(_container);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(_container));
            return _container;
        }
    }
}