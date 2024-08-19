using Application.BL.Configs.Update;
using AutoMapper;
using Presentation.Models;

namespace Presentation.MappingProfiles
{
    public class PresentationMappingProfile : Profile
    {
        public PresentationMappingProfile()
        {
            // Config
            CreateMap<UpdateConfigRequest, UpdateConfigCommand>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.User.Id))
                .ForMember(dest => dest.Instance, opt => opt.MapFrom(src => src.Instance))
                .ForMember(dest => dest.IsFirstRun, opt => opt.MapFrom(src => src.IsFirstRun))
                .ForMember(dest => dest.ShowTour, opt => opt.MapFrom(src => src.ShowTour))
                .ForMember(dest => dest.RequiresNotesForTracks, opt => opt.MapFrom(src => src.RequiresNotesForTracks))
                .ForMember(dest => dest.DeviceId, opt => opt.MapFrom(src => src.DeviceId))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.Sync, opt => opt.MapFrom(src => src.Sync))
                .ForMember(dest => dest.Update, opt => opt.MapFrom(src => src.Update))
                .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => src.Rating))
                .ForMember(dest => dest.Subscription, opt => opt.MapFrom(src => src.Subscription))
                .ForMember(dest => dest.Devices, opt => opt.MapFrom(src => src.Devices))
                .ForMember(dest => dest.Misc, opt => opt.MapFrom(src => src.Misc));

            CreateMap<UserModel, User>();
            CreateMap<SyncModel, Sync>();
            CreateMap<UpdateModel, Update>();
            CreateMap<RatingModel, Rating>();
            CreateMap<SubscriptionModel, Subscription>();
            CreateMap<DeviceModel, Device>();
            CreateMap<MiscModel, Misc>();

        }
    }
}
