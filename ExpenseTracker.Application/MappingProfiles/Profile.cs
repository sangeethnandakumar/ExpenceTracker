using Application.BL.Categories.Update;
using Application.BL.Tracks.Update;
using Application.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Track
            CreateMap<UpdateTrackCommand, Track>();
            CreateMap<Track, TrackDto>()
                   .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date.ToString("yyyy-MM-dd")));

            //Category
            CreateMap<UpdateCategoryCommand, Category>();
            CreateMap<Category, CategoryDto>();

            //Report
            CreateMap<Report, ReportDto>()
                   .ForMember(dest => dest.Start, opt => opt.MapFrom(src => src.Start.ToString("yyyy-MM-ddTHH:mm:ss.fffZ")))
                   .ForMember(dest => dest.End, opt => opt.MapFrom(src => src.End.ToString("yyyy-MM-ddTHH:mm:ss.fffZ")));

        }
    }
}
