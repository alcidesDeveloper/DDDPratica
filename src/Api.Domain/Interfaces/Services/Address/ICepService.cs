using Api.Domain.Dtos.Address;
using Api.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Domain.Interfaces.Services.Address
{
    public interface ICepService
    {
        Task<CepEntity> Post(CepDtoCreate dtoCreate);
        Task<CepEntity> GetById(int id);
        Task<IEnumerable<CepDtoResponse>> GetAll();
        Task<CepEntity> Update(CepEntity entity);
        Task<bool> Delete(int id);
    }
}
