using AutoMapper;
using DataAccessLayer.Models;
using Services.DTO; 

namespace Services.Profiles
{
    public class AdProfile : Profile
    {
        public AdProfile()
        {
            CreateMap<Ad, AdDto>()
                .ForMember(dest => dest.CreatorName, opt => opt.MapFrom(src => src.Creator.Name));

            CreateMap<AdCreateDto, Ad>()
                .ReverseMap();

            CreateMap<AdUpdateDto, Ad>()
                .ReverseMap();
        }
    }
}
