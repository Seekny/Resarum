using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPI.DTO;
using webAPI.Models;

namespace webAPI.Repositories
{
    public class ReservationsRepository
    {
        private readonly DbAppContext _context;

        public ReservationsRepository(DbAppContext context)
        {
            _context = context;
        }

        // check number of reservations behind & after the dates input, count them, verify count with all reservations ( with  roomid ) in database.
        public async Task<bool> GetReservationRange(int RoomId,DateTimeOffset Start,DateTimeOffset End)
        {
            
            var un = await _context.Reservations.Where(r => r.RoomID == RoomId && ((Start <= r.StartDate && End <= r.StartDate) || ((Start >= r.EndDate && End >= r.EndDate)))).ToListAsync();
            var deux = await _context.Reservations.Where(r => r.RoomID == RoomId).ToListAsync();
            return un.Count == deux.Count;
        }

        //Get All Reservations
        public async Task<List<Reservation>> GetReservationsAsync()
        {
            return await _context.Reservations.Include(r => r.User).Include(r => r.Room).ThenInclude(r => r.Agency).ToListAsync();
        }

        //Get reservation by ID
        public async Task<Reservation> GetReservationAsyncById(int id)
        {
            return  await _context.Reservations.Where(i => i.ReservationID == id).Include(r => r.User).Include(r => r.Room).ThenInclude(r => r.Agency).FirstOrDefaultAsync();
        }

        //Get All the reservations of 1 Room ID
        public async Task<List<Reservation>> GetReservationByRoomId( int id)
        {
            return await _context.Reservations.Where(i => i.RoomID == id).Include(r => r.Room).ToListAsync();
        }

        // Add new reservations from Form
        public async Task AddReservationAsync(Reservation reservation)
        {
            await _context.Reservations.AddAsync(reservation);
            await _context.SaveChangesAsync();
        }

        // Delete reservation
        public async Task DeleteAsyncReservation(int id)
        {
            var reservation = await _context.Reservations.SingleOrDefaultAsync(p => p.ReservationID == id);
            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();
        }

    }
}

