using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using HammerCreekBrewing.Data.Models;
using HammerCreekBrewing.ViewModels;

namespace HammerCreekBrewing.App_Start
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.CreateMap<Beer, BeerViewModel>();
        }
    }
}