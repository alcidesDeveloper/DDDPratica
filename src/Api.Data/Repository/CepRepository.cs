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
    public class CepRepository : ICepRepository
    {
        private readonly MyContext _context;

        public CepRepository(MyContext context)
        {
            _context = context;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _context.CepEntities.FindAsync(id);
            _context.CepEntities.Remove(entity);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<CepEntity> GetById(int id)
        {
            return await _context.CepEntities.FindAsync(id);
        }

        public async Task<CepEntity> InsertAsync(CepEntity entidade)
        {
            await _context.CepEntities.AddAsync(entidade);

            await _context.SaveChangesAsync();

            return entidade;
        }

        public async Task<IEnumerable<CepEntity>> SelectAllAync()
        {
            return await _context.CepEntities.Include(m=> m.Municipio).ToListAsync();
        }

        public async Task<CepEntity> Update(CepEntity entidade)
        {
            _context.CepEntities.Update(entidade);

            await _context.SaveChangesAsync();

            return entidade;
        }
    }
}
