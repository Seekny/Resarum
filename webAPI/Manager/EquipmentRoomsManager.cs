using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPI.IRepositories;
using webAPI.Models;
using webAPI.Repositories;

namespace webAPI.Manager
{
    public class EquipmentRoomsManager
    {

        private readonly EquipmentRoomsRepository _equipmentRoomsRepository;

        public EquipmentRoomsManager(EquipmentRoomsRepository equipmentsRoomsRepository)
        {
            _equipmentRoomsRepository = equipmentsRoomsRepository;
        }

        // Get Equipments for one Room By Room ID
        public async Task<List<EquipmentRooms>> GetEquipmentsByRoomID(int id)
        {
            return await _equipmentRoomsRepository.GetEquipmentsByRoomIDAsync(id);
        }
    }
}
