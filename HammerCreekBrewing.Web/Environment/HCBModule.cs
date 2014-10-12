using HammerCreekBrewing.Services;
using Autofac;
using Autofac.Integration.WebApi;
using Autofac.Integration.Mvc;
using System.Web.Http;
using HammerCreekBrewing.Data;
using AutoMapper;
using AutoMapper.Mappers;
using System.Collections.Generic;
using System.Reflection;
using HammerCreekBrewing.Web.Controllers; 

namespace HammerCreekBrewing.Web.Environment
{
    public class HCBModule : Autofac.Module
    {
        private readonly string _connectionString;
        public HCBModule(string connectionString)
        {
            _connectionString = connectionString;
        }
        protected override void Load(ContainerBuilder builder)
        {  
           // builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
           // builder.RegisterControllers(System.Reflection.Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(GlobalConfiguration.Configuration);

            builder.RegisterType<BeerMenuController>().InstancePerRequest();

            builder.RegisterType<HCBContext>().WithParameter("connectionString", _connectionString).InstancePerRequest();

            // Register other dependencies.
            builder.Register(c => new Logging()).As<ILogging>().InstancePerRequest();
                       
            // register Beer service
            builder.RegisterType<BeerService>().As<IBeerService>().InstancePerRequest();
            // register Beer style service
            builder.RegisterType<BeerStyleService>().As<IBeerStyleService>().InstancePerRequest();

            // register logging service
            builder.Register(c => new Logging()).As<ILogging>().InstancePerRequest();
            

        }
         
    }
}