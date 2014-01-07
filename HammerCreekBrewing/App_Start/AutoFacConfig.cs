using System.Web.Mvc;
using HammerCreekBrewing.Root;
using Autofac.Integration.WebApi;
using Autofac;
using HammerCreekBrewing.Factories;
using HammerCreekBrewing.Root;

namespace HammerCreekBrewing.App_Start
{
    public class AutoFacConfig
    {
        public static void RegisterDependencies() {

            // new container
            var builder = new ContainerBuilder();

            // register framework modules
            // Caching, Logginfg etc.

            // register application module
            builder.RegisterModule<StartupModule>();

            // implement controller factory and web api activator
            // autofac IoC conatainer
            var container = builder.Build();

            // initialize controller factory
            var controllerFactory = new MvcControllerFactory(container);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
            DependencyResolver.SetResolver(new AutofacWebApiDependencyResolver(container));


            // initialize web api controller activator
            //GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator),
            //    new HttpControllerActivator(container));
        }
    }
}