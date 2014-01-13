using HammerCreekBrewing.Services;
using Autofac;
using Autofac.Integration.WebApi; 
using System.Web.Http;

namespace HammerCreekBrewing.Environment
{
    public class HCBModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {


            // register Beer service
            builder.RegisterType<BeerService>().As<IBeerService>().InstancePerLifetimeScope();

            // unit of work
           /// builder.RegisterType<RepositoryContext>().As<IUnitOfWork>().InstancePerLifetimeScope();

            // register business services
            //builder.RegisterType<CheckAService>().As<ICheckAService>().InstancePerLifetimeScope();
            //builder.RegisterType<CheckBService>().As<ICheckBService>().InstancePerLifetimeScope();
            //builder.RegisterType<CheckBService>().As<ICheckBService>().InstancePerLifetimeScope();

            //builder.RegisterAssemblyTypes(typeof(CheckAService).Assembly)
            //    .Where(t => t.Name.EndsWith("Service"))
            //    .AsImplementedInterfaces()
            //    .InstancePerLifetimeScope();

            // register the admin controllers

            builder.RegisterApiControllers(typeof(HammerCreekBrewing.Areas.Admin.Controllers.BeerController).Assembly)
                .AsSelf()
                .Where(t => t.Name.EndsWith("Controller"))
                .InstancePerLifetimeScope();

            // register logging service
            builder.Register(c => new Logging())
                .As<ILogging>()
                .InstancePerLifetimeScope();


            builder.RegisterWebApiFilterProvider(GlobalConfiguration.Configuration);

            // builder.RegisterWebApiFilterProvider();
        }     

    }
}