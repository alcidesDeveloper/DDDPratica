using AutoMapper;
using CrossCutting.Mapping;
using System;
using Xunit;

namespace Api.Service.Test
{
    public class BaseTestService
    {
        public IMapper mapper { get; set; }

        public BaseTestService()
        {
            mapper = new AutoMapperFixture().GetMapper();
        }

        public void Test1()
        {

        }
    }

    public class AutoMapperFixture : IDisposable
    {
        public IMapper GetMapper()
        {
            var config = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ModelToEntityProfile());
                mc.AddProfile(new DtoToModelProfile());
                mc.AddProfile(new EntityToDtoProfile());
            });

            return config.CreateMapper();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
