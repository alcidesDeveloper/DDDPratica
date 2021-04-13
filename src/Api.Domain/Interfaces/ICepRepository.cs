using Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Interfaces
{
    public interface ICepRepository : IRepository<CepEntity>
    {
        Task<CepEntity> GetById(int id);

        Task<CepEntity> Update(CepEntity ufEntity);

        Task<bool> Delete(int id);
    }
}
