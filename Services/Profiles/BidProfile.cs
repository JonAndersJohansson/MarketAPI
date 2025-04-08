using AutoMapper;
using DataAccessLayer.Models;
using Services.DTO;

namespace Services.Profiles
{
    public class BidProfile : Profile
    {
        public BidProfile()
        {
            CreateMap<Bid, BidDto>()
                .ReverseMap();

            CreateMap<BidCreateDto, Bid>()
                .ReverseMap();

            CreateMap<BidUpdateDto, Bid>()
                .ReverseMap();
        }
    }
}
