using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using HammerCreekBrewing.Web.Mappings;
using HammerCreekBrewing.Web.Environment;
using HammerCreekBrewing.Framework.Mvc;
using HammerCreekBrewing.Data;
using Autofac.Integration.WebApi;
using System.Web.Http;
using System.Reflection;

namespace HammerCreekBrewing.Web.App_Start
{
    public static class Bootstrapper
    {
        private static string _dbconn;
      //  private static HCBContext _db;

        public static void Run(string dbConnection)
        {
            _dbconn = dbConnection; 
            InitDataBase();
            AutoMapperConfiguration.Configure();
            RegisterAutoFac(); 
        }
        public static IContainer TestRun(string dbConnection)
        {
            _dbconn = dbConnection;
            // Initilize mapping Profiles
            AutoMapperConfiguration.Configure();
            return RegisterAutoFac();
        }
        public static IContainer RegisterAutoFac()
        {
            var builder = new ContainerBuilder();

            AddMvcRegistrations(builder);
            AddRegisterations(builder);

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            return container;
        }


        private static void AddMvcRegistrations(ContainerBuilder builder)
        {
            //mvc
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinderProvider();

            //web api
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).PropertiesAutowired();
            builder.RegisterModule<AutofacWebTypesModule>();
        }



        private static void AddRegisterations(ContainerBuilder builder)
        {
            builder.RegisterModule(new HCBModule(_dbconn));
        }

        //private static IContainer SetAutofacContainer()
        //{
                         
        //    // new container
        //    var builder = new ContainerBuilder();
        //    builder.RegisterModule(new HCBModule(_dbconn));



        //    // Build the container.
        //    var container = builder.Build();

        //    // Create the depenedency resolver.
        //    var resolver = new AutofacWebApiDependencyResolver(container);

        //    // Configure Web API with the dependency resolver.
        //    GlobalConfiguration.Configuration.DependencyResolver = resolver;

        //    //// initialize controller factory
        //    //var controllerFactory = new ControllerFactory(container);
        //    //ControllerBuilder.Current.SetControllerFactory(controllerFactory);

        //    //// Set the dependency resolver for Web API.
        //    //var webApiResolver = new AutofacWebApiDependencyResolver(container);
        //    //GlobalConfiguration.Configuration.DependencyResolver = webApiResolver;

        //    // Set the dependency resolver for MVC.
        //    var mvcResolver = new AutofacDependencyResolver(container);
        //    DependencyResolver.SetResolver(mvcResolver);

        //    return container;
        //}

        private static void InitDataBase()
        { 
            var _db = new HCBContext(_dbconn);
            _db.Database.Initialize(true);
        }
    }
}