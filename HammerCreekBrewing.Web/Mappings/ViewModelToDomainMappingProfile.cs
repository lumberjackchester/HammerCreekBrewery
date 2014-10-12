using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace HammerCreekBrewing.Web.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
           // Mapper.CreateMap<CommentFormModel, Comment>();
           
            //Mapper.CreateMap<XViewModel, X()
            //    .ForMember(x => x.PropertyXYZ, opt => opt.MapFrom(source => source.Property1));     
        }
    }
}