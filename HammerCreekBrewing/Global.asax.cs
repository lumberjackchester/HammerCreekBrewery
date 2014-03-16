using Autofac;
using Autofac.Integration.WebApi;
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
using HammerCreekBrewing.Environment; 
using HammerCreekBrewing.Services;

namespace HammerCreekBrewing
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            Bootstrapper.Run(System.Configuration.ConfigurationManager.AppSettings["DatabaseContextConnectionName"]);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }


        protected void Application_Error()
        {
            var exception = Server.GetLastError();
            var logger = DependencyResolver.Current.GetService<ILogging>();
            logger.Init();
            logger.LogError("There was an unhandled application error", exception); 
        }
    }
    
}
