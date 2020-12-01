using System;
using Asdf.Users.Agregates;
using Asdf.Users.Models.Entities;
using AutoMapper;

namespace Asdf.UserDomain.Services.Mappers
{

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Id, source => source.MapFrom(source => Guid.Parse(source.Id)))
                .ForMember(dest => dest.Name, source => source.MapFrom(source => source.Name))
                .ForMember(dest => dest.Phone, source => source.MapFrom(source => source.UserName))
                .ForMember(dest => dest.Email, source => source.MapFrom(source => source.Email));

            CreateMap<Role, RoleDto>()
                .ForMember(dest => dest.Id, source => source.MapFrom(source => Guid.Parse(source.Id)))
                .ForMember(dest => dest.Name, source => source.MapFrom(source => source.Name));

            
        }
    }
}