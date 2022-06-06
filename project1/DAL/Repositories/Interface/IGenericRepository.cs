using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1.Repositories.Interface
{
    public interface IGenericRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task DeleteAsync(long id);
        Task<T> GetAsync(long id);
        Task ReplaceAsync(T t);
        Task<long> AddAsync(T t);
    }
}
