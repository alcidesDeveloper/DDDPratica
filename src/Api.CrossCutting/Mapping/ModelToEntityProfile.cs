using Api.Domain.Entities;
using Api.Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrossCutting.Mapping
{
    public class ModelToEntityProfile: Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<UserModel, UserEntity>().ReverseMap();
        }
    }
}
