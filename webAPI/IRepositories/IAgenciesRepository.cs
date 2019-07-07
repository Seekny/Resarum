using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPI.Models;

namespace webAPI.Repositories
{
    public interface IAgenciesRepository
    {
        Task<List<Agency>> GetAgenciesAsync();

        Task<Agency> GetAgencyAsyncById(int id);

    }

}

