using AutoMapper;
using ProyectoEjemplo.Data.Dto;
using ProyectoEjemplo.Data.Models;

namespace ProyectoEjemplo.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();

            CreateMap<UserInfoDto, User>();
            CreateMap<User, UserInfoDto>();

            CreateMap<UserProfileDto, UserProfile>();
            CreateMap<UserProfile, UserProfileDto>();

            // Mapeo en ambas direcciones :^)
            CreateMap<FollowerDto, Follower>().ReverseMap();
            CreateMap<Follower, FollowerInfoDto>();
        }
    }
}
