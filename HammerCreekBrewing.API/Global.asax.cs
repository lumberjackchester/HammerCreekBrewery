using HammerCreekBrewing.API.App_Start;
using System;
using System.Web;
using System.Web.Routing;
using System.Web.Http;
using HammerCreekBrewing.Services;

namespace HammerCreekBrewing.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            Bootstrapper.Run(System.Configuration.ConfigurationManager.AppSettings["DatabaseContextConnectionName"]);
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }


        //protected void Application_Error()
        //{
        //    var exception = Server.GetLastError();
        //    var logger = DependencyResolver.Current.GetService<ILogging>();
        //    logger.Init();
        //    logger.LogError("There was an unhandled application error", exception);
        //}
    }

}
