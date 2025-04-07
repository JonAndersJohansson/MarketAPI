using AutoMapper;
using DataAccessLayer.DTO;
using DataAccessLayer.Models;

namespace MarketAPI.Profiles
{
    public class AdProfile : Profile
    {
        public AdProfile()
        {
            CreateMap<Ad, AdDto>()
                .ForMember(dest => dest.CreatorName, opt => opt.MapFrom(src => src.Creator.Name));
        }
    }
}
