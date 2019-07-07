using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPI.IRepositories;
using webAPI.Models;
using webAPI.Repositories;

namespace webAPI.Manager
{
    public class RoomsManager
    {
        private readonly RoomsRepository _roomsRepository;

        public RoomsManager(RoomsRepository roomsRepository)
        {
            _roomsRepository = roomsRepository;
        }


        // Get All
        public async Task<List<Room>> GetRooms()
        {
            return await _roomsRepository.GetRoomsAsync();
        }

        // Get By ID
        public async Task<Room> GetRoomyById(int id)
        {
            return await _roomsRepository.GetRoomAsyncById(id);
        }

        //Get Room By Agency ID
        public async Task<List<Room>> GetAllRoomsByAgencyId(int id)
        {
            return await _roomsRepository.GetRoomByAgencyIdAsync(id);
        }

        //Get Room By Agency ID
        public async Task<bool> AddRoom(Room room)
        {
            await _roomsRepository.AddRoomAsync(room);

            return true;
        }
    }
}
