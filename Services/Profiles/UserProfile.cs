using AutoMapper;
using DataAccessLayer.Models;
using Services.DTO;
namespace Services.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>()
                .ReverseMap();

            CreateMap<UserCreateDto, User>()
                .ReverseMap();

            CreateMap<UserUpdateDto, User>()
                .ReverseMap();
        }
    }
}
