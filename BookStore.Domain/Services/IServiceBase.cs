using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Domain.Entities;

namespace BookStore.Domain.Services
{
    public interface IServiceBase<T> where T: EntityBase
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetSingleAsync(int id);
        
        Task<T> UpdateAsync(int id, T entity);

        Task<bool> DeleteAsync(int id);
    }
}