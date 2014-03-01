﻿using Autofac;
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


namespace HammerCreekBrewing
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Bootstrapper.Run(System.Configuration.ConfigurationManager.AppSettings["DatabaseContextConnectionName"]);


        }
    }
    
}
