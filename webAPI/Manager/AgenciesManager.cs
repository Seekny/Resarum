using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPI.Models;
using webAPI.Repositories;

namespace webAPI.Manager
{
    public class AgenciesManager
    {
        private readonly IAgenciesRepository _agenciesRepository;

        public AgenciesManager( IAgenciesRepository agenciesRepository)           
        {
            _agenciesRepository = agenciesRepository;
        }


        // Get All
        public async Task<List<Agency>> GetAgencies()
        {
            return await _agenciesRepository.GetAgenciesAsync();
        }

        // Get By ID
        public async Task<Agency> GetAgencyById(int id)
        {
            return await _agenciesRepository.GetAgencyAsyncById(id);
        }
    }
}
