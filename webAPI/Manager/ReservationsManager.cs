using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPI.DTO;
using webAPI.Models;
using webAPI.Repositories;

namespace webAPI.Manager
{
    public class ReservationsManager
    {
        private readonly ReservationsRepository _reservationsRepository;

        public ReservationsManager(ReservationsRepository reservationsRepository)
        {
            _reservationsRepository = reservationsRepository;
        }

        // Get All
        public async Task<List<Reservation>> GetReservations()
        {
            return await _reservationsRepository.GetReservationsAsync();
        }

        // Get By ID
        public async Task<Reservation> GetReservationById(int id)
        {
            return await _reservationsRepository.GetReservationAsyncById(id);
        }

        // Add Reservation
        public async Task<bool> AddReservation(Reservation reservation)
        {
             await _reservationsRepository.AddReservationAsync(reservation);

            return true;
        }

        // Delete Reservation
        public async Task<bool> DeleteReservation(int id)
        {
            await _reservationsRepository.DeleteAsyncReservation(id);
            return true;
        }

        //verify conflits  new reservations
        public async Task<bool> CheckReservationRange(int RoomId, DateTimeOffset Start,DateTimeOffset End)
        {
            return await _reservationsRepository.GetReservationRange(RoomId,Start,End);
        }

        // Get By ID
        public async Task<List<Reservation>> GetReservationAsyncByRoomId(int id)
        {
            return await _reservationsRepository.GetReservationByRoomId(id);
        }

    }
}
