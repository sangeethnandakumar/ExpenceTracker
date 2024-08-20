using Application.BL.Categories.Update;
using Application.BL.Configs.Update;
using Application.BL.Tracks.Update;
using Application.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.MappingProfiles
{
    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile()
        {
            //Track
            CreateMap<UpdateTrackCommand, Track>();
            CreateMap<Track, TrackDto>();

            //Category
            CreateMap<UpdateCategoryCommand, Category>();
            CreateMap<Category, CategoryDto>();

            //Report
            CreateMap<Report, ReportDto>();

            //DeveloperSuggestion
            CreateMap<DeveloperSuggestion, DeveloperSuggestionDto>();

            //Config
            CreateMap<UpdateConfigCommand, ConfigModel>()
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

            CreateMap<User, UserModel>();
            CreateMap<Sync, SyncModel>();
            CreateMap<Update, UpdateModel>();
            CreateMap<Rating, RatingModel>();
            CreateMap<Subscription, SubscriptionModel>();
            CreateMap<Device, DeviceModel>();
            CreateMap<Misc, MiscModel>();
        }
    }
}
