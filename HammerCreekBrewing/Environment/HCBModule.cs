using HammerCreekBrewing.Services;
using Autofac;
using Autofac.Integration.WebApi;
using Autofac.Integration.Mvc;
using System.Web.Http;
using HammerCreekBrewing.Data;

namespace HammerCreekBrewing.Environment
{
    public class HCBModule : Module
    {
        private readonly HCBContext context;
        public HCBModule(HCBContext dbcontext)
        {
            context = dbcontext;
        }
        protected override void Load(ContainerBuilder builder)
        {
            // register repository dependencies
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
           
            // builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().WithParameter("connection", new UnitOfWork(_conn)).InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().WithParameter("context", context).InstancePerLifetimeScope();
            
            // register Beer service
            builder.RegisterType<BeerService>().As<IBeerService>().InstancePerLifetimeScope();
            
            // register BeerStyle service
            builder.RegisterType<BeerStyleService>().As<IBeerStylesService>().InstancePerLifetimeScope();

            // register the admin controllers       
           // builder.RegisterControllers(typeof(HammerCreekBrewing.Areas.Admin.Controllers.BeerController).Assembly);

            //// register the public controllers 
            //builder.RegisterControllers(typeof(HammerCreekBrewing.Controllers.OnTapController).Assembly);

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