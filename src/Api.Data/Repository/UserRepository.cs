using Api.Data.Context;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class UserRepository : IUserRepository
    {
        protected readonly MyContext _myContext;


        public UserRepository(MyContext contex)
        {
            _myContext = contex;
        }

        public async Task<bool> Delete(Guid id)
        {
            var user = await _myContext.UserEntities.FindAsync(id);

            var result = _myContext.UserEntities.Remove(user);

            await _myContext.SaveChangesAsync();

            return true;
        }

        public async Task<UserEntity> FindByLogin(string email)
        {
            return await _myContext.UserEntities.FirstOrDefaultAsync(u => u.Email.Equals(email));
        }

        public async Task<UserEntity> InsertAsync(UserEntity entidade)
        {
            _myContext.UserEntities.Add(entidade);
                
            await _myContext.SaveChangesAsync();

            return entidade;
        }

        public async Task<IEnumerable<UserEntity>> SelectAllAync()
        {
            return await _myContext.UserEntities.ToListAsync();
        }

        public async Task<UserEntity> SelectByIdAync(Guid id)
        {
            var user = await _myContext.UserEntities.FindAsync(id);

            return user;
        }

        public async Task<UserEntity> UpdateAync(UserEntity user)
        {
            var userUpdated = new UserEntity();
            if (user != null)
            {
                _myContext.UserEntities.Update(user);

                await _myContext.SaveChangesAsync();

                userUpdated = await SelectByIdAync(user.Id);
            }

            return userUpdated;
        }

    }
}
