using Api.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Api.Domain.Interfaces
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        Task<UserEntity> UpdateAync(UserEntity user);

        Task<UserEntity> SelectByIdAync(Guid id);

        Task<bool> Delete(Guid id);

        Task<UserEntity> FindByLogin(string email);
    }
}
