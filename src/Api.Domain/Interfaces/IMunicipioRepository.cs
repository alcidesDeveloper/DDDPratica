using Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Interfaces
{
    public interface IMunicipioRepository : IRepository<MunicipioEntity>
    {
        Task<MunicipioEntity> GetById(int id);

        Task<MunicipioEntity> Update(MunicipioEntity ufEntity);

        Task<bool> Delete(int id);
    }
}
