using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc; 
using System.Web.Routing;
using Autofac;
using Autofac.Integration.WebApi;
using Autofac.Integration.Mvc;
using Autofac.Integration;
using WebMatrix.WebData;
using HammerCreekBrewing.Models;
using HammerCreekBrewing.Environment;
using HammerCreekBrewing.Framework.Mvc; 


namespace HammerCreekBrewing
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        private IContainer _container;
        protected void Application_Start()
        {

            // early dev only!  not in production!!
            // seed the database
            // Publish to RELEASE configuration when deploying to server, or you will fuck it up!

            if (System.Configuration.ConfigurationManager.AppSettings["DatabaseContextInitializer"] == "DropAndRecreate")
                Database.SetInitializer(new DevelopmentContextInitializer());
            else if (System.Configuration.ConfigurationManager.AppSettings["DatabaseContextInitializer"] == "CreateIfNotExists")
                Database.SetInitializer(new ProductionContextInitializer());
            else
                Database.SetInitializer<HCBContext>(null);

            var db = new HCBContext();
            db.Database.Initialize(true);
            if (!WebSecurity.Initialized)
                WebSecurity.InitializeDatabaseConnection("DefaultConnection",
                                                         "UserProfile", "UserId", "UserName", autoCreateTables: true);

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
     
            // new container
            var builder = new ContainerBuilder();
            builder.RegisterModule<HCBModule>();
            _container = builder.Build();

            // initialize controller factory
            var controllerFactory = new ControllerFactory(_container);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(_container));


            // initialize web api controller activator
            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator),
                                                               new HttpControllerActivator(_container));
        }
    }
}