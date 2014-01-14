using HammerCreekBrewing.Services;
using Autofac;
using Autofac.Integration.WebApi;
using Autofac.Integration.Mvc;
using System.Web.Http;

namespace HammerCreekBrewing.Environment
{
    public class HCBModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        { 

            // register Beer service
            builder.RegisterType<BeerService>().As<IBeerService>().InstancePerLifetimeScope();

            // register the admin controllers       
            builder.RegisterControllers(typeof(HammerCreekBrewing.Areas.Admin.Controllers.BeerController).Assembly);

            // register the public controllers 
            builder.RegisterControllers(typeof(HammerCreekBrewing.Controllers.OnTapController).Assembly);

            //register home controller
            //    builder.RegisterControllers(typeof(HammerCreekBrewing.Controllers.HomeController).Assembly);      

            // register logging service
            builder.Register(c => new Logging())
                .As<ILogging>()
                .InstancePerLifetimeScope();

            builder.RegisterFilterProvider();
        }     

    }
}