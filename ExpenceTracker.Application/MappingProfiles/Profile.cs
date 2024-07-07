using Application.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Track → TrackDto
            CreateMap<Track, TrackDto>()
                   .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date.ToString("yyyy-MM-dd")));

        }
    }
}
