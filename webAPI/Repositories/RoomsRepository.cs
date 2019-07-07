using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPI.Models;

namespace webAPI.Repositories
{
    public class RoomsRepository
    {
        private readonly DbAppContext _context;

        public RoomsRepository(DbAppContext context)
        {
            _context = context;
        }

        //Get aLl rooms
        public async Task<List<Room>> GetRoomsAsync()
        {
            return await _context.Rooms.Include(a => a.Reservations).Include(s => s.Agency).ToListAsync();
        }

        //Get Room By iD
        public async Task<Room> GetRoomAsyncById(int id)
        {
            return await _context.Rooms.Where(a => a.RoomID == id).Include(r => r.Reservations).Include(er => er.EquipmentsRooms).Include(s => s.Agency).FirstOrDefaultAsync();

        }

        // Get Rooms By Agency ID
        public async Task<List<Room>> GetRoomByAgencyIdAsync(int id)
        {
            return await _context.Rooms.Where(i => i.AgencyID == id).Include(a => a.Agency).ToListAsync();
        }


        // Add room - not use atm
        public async Task AddRoomAsync(Room room)
        {
            await _context.Rooms.AddAsync(room);
            await _context.SaveChangesAsync();
        }
    }
}
