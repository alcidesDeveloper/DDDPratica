using Api.Domain.Dtos;
using Api.Domain.Dtos.User;
using Api.Domain.Models;
using AutoMapper;


namespace CrossCutting.Mapping
{
    public class DtoToModelProfile: Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<UserModel, UserDto>().ReverseMap();
            CreateMap<UserModel, UserDtoCreate>().ReverseMap();
            CreateMap<UserModel, UserDtoUpdate>().ReverseMap();
        }
    }
}
