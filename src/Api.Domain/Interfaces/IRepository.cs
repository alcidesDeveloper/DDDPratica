using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Domain.Interfaces
{
    public interface IRepository<T> where T: class
    {
        Task<T> InsertAsync(T entidade);

        Task<IEnumerable<T>> SelectAllAync();
    }
}