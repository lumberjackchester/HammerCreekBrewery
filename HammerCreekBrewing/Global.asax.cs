using Autofac;
using Autofac.Integration.Mvc;
using HammerCreekBrewing.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Http; 
using WebMatrix.WebData;
using HammerCreekBrewing.Framework.Mvc;

namespace HammerCreekBrewing
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private IContainer _container;
        protected void Application_Start()
        {
            //AreaRegistration.RegisterAllAreas();
            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //RouteConfig.RegisterRoutes(RouteTable.Routes);

            //BundleConfig.RegisterBundles(BundleTable.Bundles);

            //if (System.Configuration.ConfigurationManager.AppSettings["DatabaseContextInitializer"] == "DropAndRecreate")
            //    Database.SetInitializer(new DevelopmentContextInitializer());
            //else if (System.Configuration.ConfigurationManager.AppSettings["DatabaseContextInitializer"] == "CreateIfNotExists")
            //    Database.SetInitializer(new ProductionContextInitializer());
            //else
            //    Database.SetInitializer<HCBContext>(null);

            var db = new HCBContext();
            db.Database.Initialize(true);
            if (!WebSecurity.Initialized)
                WebSecurity.InitializeDatabaseConnection("HammerCreekBrewingContext",
                                                         "UserProfile", "UserId", "UserName", autoCreateTables: true);
            AreaRegistration.RegisterAllAreas();

            //WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //FilterConfig.RegisterHttpFilters(GlobalConfiguration.Configuration.Filters);

            //GlobalConfiguration.Configuration.Filters.Add(new ExceptionHandlingAttribute());
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //AuthConfig.RegisterAuth();
            
            // new container
            var builder = new ContainerBuilder();
            builder.RegisterModule<HammerCreekBrewing.Environment.HCBModule>();
            _container = builder.Build();

            // initialize controller factory
            var controllerFactory = new ControllerFactory(_container);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(_container));

        }
    }
}
