using Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Interfaces
{
    public interface IUfRepository: IRepository<UfEntity>
    {
        Task<UfEntity> GetById(int id);

        Task<UfEntity> Update(UfEntity ufEntity);

        Task<bool> Delete(int id);
    }
}
