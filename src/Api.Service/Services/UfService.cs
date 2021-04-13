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
    public class UfService : IUfService
    {
        private readonly IUfRepository _repository;
        private readonly IMapper _mapper;

        public UfService(IUfRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UfEntity>> GetAll()
        {
            var result = await _repository.SelectAllAync();

            return result;
        }

        public Task<UfEntity> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<UfEntity> Post(UfDtoCreate dtoCreate)
        {
            var entity = _mapper.Map<UfEntity>(dtoCreate);
            var result = await _repository.InsertAsync(entity);

            return result;
        }

        public Task<UfEntity> Update(UfEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
