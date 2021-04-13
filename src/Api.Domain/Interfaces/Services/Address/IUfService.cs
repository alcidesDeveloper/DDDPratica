using Api.Domain.Dtos.Address;
using Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Interfaces.Services.Address
{
    public interface IUfService
    {
        Task<UfEntity> Post(UfDtoCreate dtoCreate);
        Task<UfEntity> GetById(int id);
        Task<IEnumerable<UfEntity>> GetAll();
        Task<UfEntity> Update(UfEntity entity);
        Task<bool> Delete(int id);
    }
}
