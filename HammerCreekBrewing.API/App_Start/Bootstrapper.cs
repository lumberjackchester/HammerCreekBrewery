using Autofac;
using Autofac.Integration.WebApi;
using HammerCreekBrewing.API.Mappings;
using HammerCreekBrewing.API.Environment;
//using HammerCreekBrewing.API.Framework.Mvc;
using HammerCreekBrewing.Data;
using Autofac.Integration.WebApi;
using System.Web.Http;

namespace HammerCreekBrewing.API.App_Start
{
    public static class Bootstrapper
    {
       // private static string _dbconn;
      //  private static HCBContext _db;

        public static void Run()
        {
           // _dbconn = dbConnection; 
            InitDataBases();
            AutoMapperConfiguration.Configure();
            SetAutofacContainer(); 
        }
        public static IContainer TestRun(string dbConnection)
        {
            //_dbconn = dbConnection;
            // Initilize mapping Profiles
            AutoMapperConfiguration.Configure();
            return SetAutofacContainer();
        }
        private static IContainer SetAutofacContainer()
        {
            // new container
            var builder = new ContainerBuilder();
            builder.RegisterModule(new HCBModule()); 
            // Build the container.
            var container = builder.Build();
            // Set the dependency resolver for Web API.
            var webApiResolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = webApiResolver;
            return container;
        }

        private static void InitDataBases()
        { 
            var _dbHCB = new HCBContext();
            _dbHCB.Database.Initialize(true);
            var _dbAuth = new AuthContext();
            _dbAuth.Database.Initialize(true);
        }
    }
}