using Abp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace webAPI.Generic
{
    public interface IGenericRepository<T>
        where T : IEntity<int>
    {
        Task<List<T>> GetAllAsync();

        Task<T> GetOneAsync(int id);
    }
}
