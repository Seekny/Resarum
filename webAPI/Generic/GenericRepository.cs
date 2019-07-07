using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using webAPI.Models;

namespace webAPI.Generic
{
    public class GenericRepository<T> : IGenericRepository<T>
        where T : class, IEntity<int>
    {
        protected readonly DbAppContext _context;
        public GenericRepository(DbAppContext context)
        {
            _context = context;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetOneAsync(int id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(t => t.Id == id);
        }

    }
}
