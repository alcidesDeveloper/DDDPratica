using Api.Domain.Dtos.Address;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.Address;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class MunicipioService : IMunicipioService
    {
        private readonly IMunicipioRepository _repository;
        private readonly IMapper _mapper;

        public MunicipioService(IMunicipioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MunicipioEntity>> GetAll()
        {
            var result = await _repository.SelectAllAync();

            return result;
        }

        public Task<MunicipioEntity> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<MunicipioEntity> Post(MunicipioDtoCreate dtoCreate)
        {
            var entity = _mapper.Map<MunicipioEntity>(dtoCreate);
            var result = await _repository.InsertAsync(entity);

            return result;
        }

        public Task<MunicipioEntity> Update(MunicipioEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
