using AutoMapper;
using Domain.Entities;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCutting.Mappings
{
    class ModelToEntityFile : Profile
    {
        public ModelToEntityFile()
        {
            CreateMap<UserEntity, UserModel>()
                .ReverseMap(); //transforma uma userEntity em UserModel
        }
    }
}
