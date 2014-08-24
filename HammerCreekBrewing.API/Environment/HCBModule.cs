using HammerCreekBrewing.Services;
using Autofac;
using Autofac.Integration.WebApi;
using System.Web.Http;
using HammerCreekBrewing.Data;
using AutoMapper;
using AutoMapper.Mappers;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using HammerCreekBrewing.Data.Entities; 

namespace HammerCreekBrewing.API.Environment
{
    public class HCBModule : Module
    {
        //private readonly string _connectionString;
        //public HCBModule(string connectionString)
        //{
        //    _connectionString = connectionString;
        //}
        protected override void Load(ContainerBuilder builder)
        {  

            //Register Data Contexts
           // builder.RegisterType<HCBContext>().WithParameter("connectionString", _connectionString).InstancePerRequest();
            builder.RegisterType<HCBContext>().InstancePerRequest();
            builder.RegisterType<AuthContext>().InstancePerRequest();

            builder.Register(u => new UserStore<ApplicationUser>()).As<IUserStore<ApplicationUser>>().InstancePerRequest();
            // register 
                       
            // register Beer service
            builder.RegisterType<BeerService>().As<IBeerService>().InstancePerRequest();
            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>().InstancePerRequest();

            // register logging service
            builder.Register(c => new Logging()).As<ILogging>().InstancePerRequest();

            //builder.RegisterControllers(System.Reflection.Assembly.GetExecutingAssembly());
            ////register Web API controler
            builder.RegisterApiControllers(System.Reflection.Assembly.GetExecutingAssembly());

          //  builder.RegisterFilterProvider();
            builder.RegisterWebApiFilterProvider(GlobalConfiguration.Configuration);

        }

    }
}