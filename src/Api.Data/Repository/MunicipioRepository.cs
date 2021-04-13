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
    public class MunicipioRepository : IMunicipioRepository
    {
        private readonly MyContext _context;

        public MunicipioRepository(MyContext context)
        {
            _context = context;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _context.MunicipioEntities.FindAsync(id);
            _context.MunicipioEntities.Remove(entity);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<MunicipioEntity> GetById(int id)
        {
            return await _context.MunicipioEntities.FindAsync(id);
        }

        public async Task<MunicipioEntity> InsertAsync(MunicipioEntity entidade)
        {
            await _context.MunicipioEntities.AddAsync(entidade);

            await _context.SaveChangesAsync();

            return entidade;
        }

        public async Task<IEnumerable<MunicipioEntity>> SelectAllAync()
        {
            return await _context.MunicipioEntities.Include(m=> m.Uf).ToListAsync();
        }

        public async Task<MunicipioEntity> Update(MunicipioEntity entidade)
        {
            _context.MunicipioEntities.Update(entidade);

            await _context.SaveChangesAsync();

            return entidade;
        }
    }
}
