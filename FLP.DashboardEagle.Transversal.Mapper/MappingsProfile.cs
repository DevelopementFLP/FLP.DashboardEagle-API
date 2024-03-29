using AutoMapper;
using FLP.DashboardEagle.Application.Dto;
using FLP.DashboardEagle.Domain.Entity;

namespace FLP.DashboardEagle.Transversal.Mapper
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile() 
        {
            CreateMap<EagleResponse, EagleResponseDto>().ReverseMap();
        }
    }
}
