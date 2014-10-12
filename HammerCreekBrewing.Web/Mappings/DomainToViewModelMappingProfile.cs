using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using HammerCreekBrewing.Data.Models;
using HammerCreekBrewing.Data.ViewModels;


namespace HammerCreekBrewing.Web.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {

            //Mapper.CreateMap<Beer, BeerMenuViewModel>();
            Mapper.CreateMap<Beer, BeerViewModel>().ForMember(x => x.StyleName, opt => opt.MapFrom(source => source.Style.StyleName))
                                                      .ForMember(x => x.BreweryName, opt => opt.MapFrom(source => source.Brewery.Name))
                                                      .ForMember(x => x.LocationName, opt => opt.MapFrom(source => source.Location.Name)) 
                                                      .ForMember(x => x.KeggedDate, opt => opt.MapFrom(source => source.KeggedDate.HasValue ? source.KeggedDate.Value.ToString("dd MMM yyyy") : "N/A"))
                                                      .ForMember(x => x.TappedDate, opt => opt.MapFrom(source => source.TappedDate.HasValue ? source.TappedDate.Value.ToString("dd MMM yyyy") : "N/A"))
                                                      .ForMember(x => x.BrewDate, opt => opt.MapFrom(source => source.BrewDate.ToString("dd MMM yyyy")))
                                                      .ForMember(x => x.Id, opt => opt.MapFrom(source => source.BeerId))
                                                      .ForMember(x => x.TapName, opt => opt.MapFrom(source => source.TapName))
                                                      .ForMember(x => x.Name, opt => opt.MapFrom(source => source.Name))
                                                      .ForMember(x => x.Abv, opt => opt.MapFrom(source => source.Abv))
                                                      .ForMember(x => x.KegId, opt => opt.MapFrom(source => source.KegId));


            Mapper.CreateMap<Location, LocationViewModel>().ForMember(x => x.Id, opt => opt.MapFrom(source => source.LocationId))
                                                      .ForMember(x => x.Name, opt => opt.MapFrom(source => source.Name));
            //Mapper.CreateMap<Comment, CommentsViewModel>();
            //Mapper.CreateMap<UserProfile, UserProfileFormModel>();
            //Mapper.CreateMap<Group, GroupGoalFormModel>();
            //Mapper.CreateMap<Group, GroupFormModel>();
            //Mapper.CreateMap<GroupGoal, GroupGoalFormModel>();
            //Mapper.CreateMap<GroupInvitation, NotificationViewModel>();
            //Mapper.CreateMap<SupportInvitation, NotificationViewModel>();
            //Mapper.CreateMap<Group, GroupViewModel>();
            //Mapper.CreateMap<GroupGoal, GroupGoalViewModel>();
            //Mapper.CreateMap<GroupComment, GroupCommentsViewModel>();
            //Mapper.CreateMap<Focus, FocusViewModel>();
            //Mapper.CreateMap<Focus, FocusFormModel>();
            //Mapper.CreateMap<GroupRequest, GroupRequestViewModel>();
            //Mapper.CreateMap<FollowRequest, NotificationViewModel>();
            //Mapper.CreateMap<ApplicationUser, FollowersViewModel>();
            //Mapper.CreateMap<ApplicationUser, FollowingViewModel>();
            //Mapper.CreateMap<Update, UpdateFormModel>();
            //Mapper.CreateMap<GroupUpdate, GroupUpdateFormModel>();
            //Mapper.CreateMap<Update, UpdateViewModel>();
            //Mapper.CreateMap<GroupUpdate, GroupUpdateViewModel>();
            ////Mapper.CreateMap<X, XViewModel>()
            ////    .ForMember(x => x.Property1, opt => opt.MapFrom(source => source.PropertyXYZ));
            //Mapper.CreateMap<Goal, GoalListViewModel>().ForMember(x => x.SupportsCount, opt => opt.MapFrom(source => source.Supports.Count))
            //                                          .ForMember(x => x.UserName, opt => opt.MapFrom(source => source.User.UserName))
            //                                          .ForMember(x => x.StartDate, opt => opt.MapFrom(source => source.StartDate.ToString("dd MMM yyyy")))
            //                                          .ForMember(x => x.EndDate, opt => opt.MapFrom(source => source.EndDate.ToString("dd MMM yyyy")));
            //Mapper.CreateMap<Group, GroupsItemViewModel>().ForMember(x => x.CreatedDate, opt => opt.MapFrom(source => source.CreatedDate.ToString("dd MMM yyyy")));



        }
    }

}