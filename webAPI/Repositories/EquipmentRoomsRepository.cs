using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPI.Models;

namespace webAPI.Repositories
{
    public class EquipmentRoomsRepository
    {
        private readonly DbAppContext _context;

        public EquipmentRoomsRepository(DbAppContext context)
        {
            _context = context;
        }

        // Get Equipments from one Room by RoomID
        public async Task<List<EquipmentRooms>> GetEquipmentsByRoomIDAsync(int id)
        {
            return await _context.EquipmentsRooms.Include(e => e.Equipment).Where(i => i.RoomID == id).ToListAsync();
        }

       
    }
}
