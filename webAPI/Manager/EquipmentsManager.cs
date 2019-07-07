using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPI.Models;
using webAPI.Repositories;

namespace webAPI.Manager
{
    public class EquipmentsManager
    {
        private readonly EquipmentsRepository _equipmentsRepository;

        public EquipmentsManager(EquipmentsRepository equipmentsRepository)
        {
            _equipmentsRepository = equipmentsRepository;
        }
        
        // Get All
        public async Task<List<Equipment>> GetEquipments()
        {
            return await _equipmentsRepository.GetEquipmentsAsync();
        }
    }
}
