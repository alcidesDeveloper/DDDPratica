using Api.Domain.Dtos.Address;
using Api.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Domain.Interfaces.Services.Address
{
    public interface IMunicipioService
    {
        Task<MunicipioEntity> Post(MunicipioDtoCreate dtoCreate);
        Task<MunicipioEntity> GetById(int id);
        Task<IEnumerable<MunicipioEntity>> GetAll();
        Task<MunicipioEntity> Update(MunicipioEntity entity);
        Task<bool> Delete(int id);
    }
}
