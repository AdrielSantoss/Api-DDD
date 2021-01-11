using AutoMapper;
using Domain.Dtos;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCutting.Mappings
{
    class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<UserModel, UserDto>()
            .ReverseMap(); //Dto para model e model para Dto
            
            /*
             * Fluxo: 
             1 -Entra pela controller em Dto 
             2 - Converte Dto em Model (na camada service) -> CreateMap<UserModel, UserDto>()
             3 - pegar o modelo e mapear para uma entidade (na camada service) -> CreateMap<UserEntity, UserModel>()
             4 - a entity vai ser convertida nos result para respostas (resultado depois de pesistir no banco) -> CreateMap<UserDtoUpdateResult, UserEntity>(), CreateMap<UserDtoCreateResult, UserEntity>(), CreateMap<UserDto, UserEntity>()
             */
        }
    }
}
