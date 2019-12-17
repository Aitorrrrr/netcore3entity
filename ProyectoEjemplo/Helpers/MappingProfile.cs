using AutoMapper;
using ProyectoEjemplo.Data.Dto;
using ProyectoEjemplo.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        }
    }
}
