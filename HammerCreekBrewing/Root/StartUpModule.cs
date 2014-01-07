using HammerCreekBrewing.Controllers;
using HammerCreekBrewing.Services;
using Repository;
using Autofac;

namespace HammerCreekBrewing.Root
{
    public class StartupModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {


            // unit of work
            builder.RegisterType<RepositoryContext>().As<IUnitOfWork>().InstancePerLifetimeScope();

            // register business services
            //builder.RegisterType<CheckAService>().As<ICheckAService>().InstancePerLifetimeScope();
            //builder.RegisterType<CheckBService>().As<ICheckBService>().InstancePerLifetimeScope();
            //builder.RegisterType<CheckBService>().As<ICheckBService>().InstancePerLifetimeScope();

            //builder.RegisterAssemblyTypes(typeof(CheckAService).Assembly)
            //    .Where(t => t.Name.EndsWith("Service"))
            //    .AsImplementedInterfaces()
            //    .InstancePerLifetimeScope();

            // register the home controller
            builder.RegisterType<BeerController>().AsSelf().InstancePerLifetimeScope();


        }     

    }
}