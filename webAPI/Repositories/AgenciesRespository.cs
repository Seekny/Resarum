using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPI.DTO;
using webAPI.Models;

namespace webAPI.Repositories
{
    public class AgenciesRepository : IAgenciesRepository
    {
        private readonly DbAppContext _context;

        public AgenciesRepository(DbAppContext context)
        {
            _context = context;
        }

        // Get All
        public async Task<List<Agency>> GetAgenciesAsync()
        {
            return await _context.Agencies.Include(a => a.Rooms).ToListAsync();
        }

        // Get By ID
        public async Task<Agency> GetAgencyAsyncById(int id)
        {
            return await _context.Agencies.Where(i =>i.AgencyID == id).Include(a => a.Rooms).FirstOrDefaultAsync();
        }

        
    }
}
