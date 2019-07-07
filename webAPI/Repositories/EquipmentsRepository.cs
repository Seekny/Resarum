using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPI.Models;

namespace webAPI.Repositories
{
    public class EquipmentsRepository
    {
        private readonly DbAppContext _context;

        public EquipmentsRepository(DbAppContext context)
        {
            _context = context;
        }

        public async Task<List<Equipment>> GetEquipmentsAsync()
        {
            return await _context.Equipments.ToListAsync();
        }
    }
}
