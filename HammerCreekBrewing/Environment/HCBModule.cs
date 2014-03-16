using HammerCreekBrewing.Services;
using Autofac;
using Autofac.Integration.WebApi;
using Autofac.Integration.Mvc;
using System.Web.Http;
using HammerCreekBrewing.Data;
using AutoMapper;
using AutoMapper.Mappers;
using System.Collections.Generic; 

namespace HammerCreekBrewing.Environment
{
    public class HCBModule : Module
    {
        private readonly string _connectionString;
        public HCBModule(string connectionString)
        {
            _connectionString = connectionString;
        }
        protected override void Load(ContainerBuilder builder)
        {  

            //Register HCDbcontext
           // builder.RegisterType<HCBContext>().As<Idb>().WithParameter("context", context).InstancePerLifetimeScope();

            builder.RegisterType<HCBContext>().WithParameter("connectionString", _connectionString).InstancePerApiRequest();

            // Register other dependencies.
            builder.Register(c => new Logging()).As<ILogging>().InstancePerApiRequest();
                       
            // register Beer service
            builder.RegisterType<BeerService>().As<IBeerService>().InstancePerApiRequest();

            // register logging service
            builder.Register(c => new Logging()).As<ILogging>().InstancePerApiRequest();

            builder.RegisterControllers(System.Reflection.Assembly.GetExecutingAssembly());
            ////register Web API controler
            builder.RegisterApiControllers(System.Reflection.Assembly.GetExecutingAssembly());

            builder.RegisterFilterProvider();
            builder.RegisterWebApiFilterProvider(GlobalConfiguration.Configuration);

        }
        //protected override void Load(ContainerBuilder builder)
        //{

        //    //// register auto mapping
        //    //builder.Register(ctx => new ConfigurationStore(new TypeMapFactory(), MapperRegistry.Mappers))
        //    //       .AsImplementedInterfaces()
        //    //       .SingleInstance()
        //    //       .OnActivating(x =>
        //    //       {
        //    //           foreach (var profile in x.Context.Resolve<IEnumerable<Profile>>())
        //    //           {
        //    //               x.Instance.AddProfile(profile);
        //    //           }
        //    //       });
        //    //builder.RegisterType<MappingEngine>()
        //    //       .As<IMappingEngine>();

        //    // register repository dependencies
        //    builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
           
        //    // builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().WithParameter("connection", new UnitOfWork(_conn)).InstancePerLifetimeScope();
        //    builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().WithParameter("context", context).InstancePerLifetimeScope();
            
        //    // register Beer service
        //    builder.RegisterType<BeerService>().As<IBeerService>().InstancePerLifetimeScope();
            
        //    // register BeerStyle service
        //    builder.RegisterType<BeerStyleService>().As<IBeerStylesService>().InstancePerLifetimeScope();

        //    // register the admin controllers       
        //   // builder.RegisterControllers(typeof(HammerCreekBrewing.Areas.Admin.Controllers.BeerController).Assembly);

        //    //// register the public controllers 
        //    //builder.RegisterControllers(typeof(HammerCreekBrewing.Controllers.OnTapController).Assembly);

        //    //register home controller
        //    builder.RegisterControllers(typeof(HammerCreekBrewing.Controllers.HomeController).Assembly);      

        //    //register Web API controler
        //    builder.RegisterControllers(typeof(HammerCreekBrewing.Controllers.BeerMenuController).Assembly);  

        //    // register logging service
        //    builder.Register(c => new Logging())
        //        .As<ILogging>()
        //        .InstancePerLifetimeScope();



        //    builder.RegisterFilterProvider();
        //}     

    }
}