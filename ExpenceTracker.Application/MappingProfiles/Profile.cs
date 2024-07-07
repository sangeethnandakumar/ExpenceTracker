using Application.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Employee → EmployeeDto
            CreateMap<Employee, EmployeeDto>()
                   .ForMember(dest => dest.Dob, opt => opt.MapFrom(src => src.Dob.ToString("yyyy-MM-ddTHH:mm:ss.fffZ")));
        }
    }
}
