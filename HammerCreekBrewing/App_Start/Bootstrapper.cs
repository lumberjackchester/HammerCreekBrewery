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
using Autofac.Integration.WebApi;
using System.Web.Http;

namespace HammerCreekBrewing
{
    public static class Bootstrapper
    {
        private static string _dbconn;
      //  private static HCBContext _db;

        public static void Run(string dbConnection)
        {
            _dbconn = dbConnection; 
            InitDataBase();
            AutoMapperConfiguration.Configure();
            SetAutofacContainer(); 
        }
        public static IContainer TestRun(string dbConnection)
        {
            _dbconn = dbConnection;
            // Initilize mapping Profiles
            AutoMapperConfiguration.Configure();
            return SetAutofacContainer();
        }
        private static IContainer SetAutofacContainer()
        {
                         
            // new container
            var builder = new ContainerBuilder();
            builder.RegisterModule(new HCBModule(_dbconn));           


            // Build the container.
            var container = builder.Build();

            // initialize controller factory
            var controllerFactory = new ControllerFactory(container);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);

            // Set the dependency resolver for Web API.
            var webApiResolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = webApiResolver;

            // Set the dependency resolver for MVC.
            var mvcResolver = new AutofacDependencyResolver(container);
            DependencyResolver.SetResolver(mvcResolver);

            return container;
        }

        private static void InitDataBase()
        { 
            var _db = new HCBContext(_dbconn);
            _db.Database.Initialize(true);
        }
    }
}