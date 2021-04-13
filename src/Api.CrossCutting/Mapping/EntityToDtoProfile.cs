using Api.Domain.Dtos;
using Api.Domain.Dtos.Address;
using Api.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrossCutting.Mapping
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<UserDto, UserEntity>().ReverseMap();

            CreateMap<UserDtoCreateResult, UserEntity>().ReverseMap();

            CreateMap<UserDtoUpdateResult, UserEntity>().ReverseMap();
            
            CreateMap<CepDtoCreate, CepEntity>().ReverseMap();

            CreateMap<UfDtoCreate, UfEntity>().ReverseMap();

            CreateMap<MunicipioDtoCreate, MunicipioEntity>().ReverseMap();

            CreateMap<CepDtoResponse, CepEntity>().ReverseMap();
        }
    }
}
