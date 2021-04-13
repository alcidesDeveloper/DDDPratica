using Api.Data.Context;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class UfRepository : IUfRepository
    {
        private readonly MyContext _context;

        public UfRepository(MyContext context)
        {
            _context = context;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _context.UfEntities.FindAsync(id);
            _context.UfEntities.Remove(entity);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<UfEntity> GetById(int id)
        {
            return await _context.UfEntities.FindAsync(id);
        }

        public async Task<UfEntity> InsertAsync(UfEntity entidade)
        {
            await _context.UfEntities.AddAsync(entidade);

            await _context.SaveChangesAsync();

            return entidade;
        }

        public async Task<IEnumerable<UfEntity>> SelectAllAync()
        {
            return await _context.UfEntities.Include(uf=> uf.Municipios).ToListAsync();
        }

        public async Task<UfEntity> Update(UfEntity ufEntity)
        {
            _context.UfEntities.Update(ufEntity);

            await _context.SaveChangesAsync();

            return ufEntity;
        }
    }
}
