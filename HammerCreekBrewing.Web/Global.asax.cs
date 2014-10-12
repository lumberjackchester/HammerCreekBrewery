using HammerCreekBrewing.Services;
using HammerCreekBrewing.Web.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace HammerCreekBrewing.Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
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
