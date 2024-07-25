using Application.BL.Categories.Update;
using Application.BL.Tracks.Update;
using Application.Constants;
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
            CreateMap<Track, TrackDto>();

            //Category
            CreateMap<UpdateCategoryCommand, Category>();
            CreateMap<Category, CategoryDto>();

            //Report
            CreateMap<Report, ReportDto>();
        }
    }
}
