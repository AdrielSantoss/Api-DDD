using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCutting.Mappings
{
    class EntityToDtoProfile : Profile //Implementação do AutoMapper
    {
        public EntityToDtoProfile()
        {
            CreateMap<UserDto, UserEntity>()
            .ReverseMap(); //result de um get

            CreateMap<UserDtoCreateResult, UserEntity>()
                .ReverseMap(); //result de um insert

            CreateMap<UserDtoUpdateResult, UserEntity>()
                .ReverseMap(); //result de um update
        }
    }
}
