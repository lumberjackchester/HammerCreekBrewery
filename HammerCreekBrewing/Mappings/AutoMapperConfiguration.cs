using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace HammerCreekBrewing.Mappings
{
    public class AutoMapperConfiguration
    {
        //public static void Configure()
        //{
        //    Mapper.Initialize(x =>
        //    {
        //        x.AddProfile<DomainToViewModelMappingProfile>();
        //        x.AddProfile<ViewModelToDomainMappingProfile>();
        //    });
        //}
        public static void Configure()
        {
            Mapper.Initialize(x => GetConfiguration(Mapper.Configuration));
            Mapper.AssertConfigurationIsValid();
        }

        private static void GetConfiguration(IConfiguration configuration)
        {
            var profiles = typeof(DomainToViewModelMappingProfile).Assembly.GetTypes().Where(x => typeof(Profile).IsAssignableFrom(x));
            foreach (var profile in profiles)
            {
                configuration.AddProfile(Activator.CreateInstance(profile) as Profile);
            }
        }
    }
}