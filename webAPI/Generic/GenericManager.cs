using Abp.Domain.Entities;
using HoMe.ServicesInterfaces.Generic;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace webAPI.Generic
{
    public class GenericManager<T, R> : IGenericManager<T>
        where T : IEntity<int>
        where R : IGenericRepository<T>
    {
        protected readonly R _repository;

        public GenericManager(IServiceProvider provider)
        {
            _repository = (R)provider.GetService(typeof(R));
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<T> GetOneAsync(int id)
        {
            return await _repository.GetOneAsync(id);
        }

    }
}
