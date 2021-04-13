using Api.Domain.Dtos.Address;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.Address;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CepService : ICepService
    {
        private readonly ICepRepository _repository;
        private readonly IMapper _mapper;
        public CepService(ICepRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CepDtoResponse>> GetAll()
        {
            var entities = await _repository.SelectAllAync();

            return _mapper.Map<IEnumerable<CepDtoResponse>>(entities);
        }

        public Task<CepEntity> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<CepEntity> Post(CepDtoCreate dtoCreate)
        {
            var entity = _mapper.Map<CepEntity>(dtoCreate);
            var result = await _repository.InsertAsync(entity);

            return result;
        }

        public Task<CepEntity> Update(CepEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
