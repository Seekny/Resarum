using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webAPI.DTO;
using webAPI.Manager;
using webAPI.Models;

namespace webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReservationsController : ControllerBase
    {
        private readonly ReservationsManager _reservationsManager;
        private readonly UsersManager _usersManager;
        private readonly IMapper _mapper;

        public ReservationsController(DbAppContext context, IMapper mapper, ReservationsManager reservationsManager, UsersManager usersManager)
        {
            _mapper = mapper;
            _reservationsManager = reservationsManager;
            _usersManager = usersManager;
        }

        // GET: api/Reservations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservationDTO>>> GetAllReservations()
        { 
            var reservations = await _reservationsManager.GetReservations();

            return _mapper.Map<List<ReservationDTO>>(reservations);
        }

        // GET: api/Reservations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReservationDTO>> GetReservation(int id)
        {            

            var reservation = await _reservationsManager.GetReservationById(id);

            if (reservation == null)
            {
                return NotFound();
            }

            return _mapper.Map<ReservationDTO>(reservation);
        }

        // POST: api/Reservations
        [HttpPost]
        public async Task<ActionResult> AddReservationAsync([FromBody]ReservationDTO reservation)
        {
          



            if (reservation.Note == null)
            {
                reservation.Note = "Aucune note";
            }
            if (reservation == null)
            {
                return new EmptyResult();
            }

            if (reservation.StartDate < DateTime.Now || reservation.StartDate > reservation.EndDate)
            {
                var result = new ObjectResult(reservation)
                {
                    StatusCode = 409
                };
                return result;
            }
                // call manager to find if id is taken or not
                if (! await _reservationsManager.CheckReservationRange(reservation.RoomID, reservation.StartDate, reservation.EndDate))
                {

                //return StatusCode(409 );
                var result = new ObjectResult(reservation)
                {
                    StatusCode = 409
                };
                return result;
            }
            else
            {

                var userLdap = _usersManager.GetUsername();

                bool userExist = await _usersManager.VerifyUsername(userLdap);

                if (!userExist)
                {
                    await _usersManager.AddUser(userLdap);
                }

                var user = await _usersManager.GetUserIDAsync(userLdap);

                reservation.UserID = user.UserID;


                reservation.StartDate = reservation.StartDate.AddSeconds(-reservation.StartDate.Second);
                reservation.EndDate = reservation.EndDate.AddSeconds(-reservation.EndDate.Second);
                // find DTO & Mapping
                var reservationMapped = _mapper.Map<ReservationDTO, Reservation>(reservation);
                //call manager once again to add it this time
                await _reservationsManager.AddReservation(reservationMapped);

                return Ok();
            }
        }
        
        // DELETE: api/Reservations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Reservation>> DeleteReservation(int id)
        {
            
            // call manager reservation to delete reservation
            var result = await _reservationsManager.DeleteReservation(id);               
            if (result)
            {
                return Ok();
            }
            else
            {
                return new BadRequestResult();
            }
            
        }


        // GET: api/Reservations/5
        [HttpGet("Room={id}")]
        public async Task<ActionResult<List<ReservationDTO>>> GetReservationsByRoomId(int id)
        {

            
            var reservation = await _reservationsManager.GetReservationAsyncByRoomId(id);

            if (reservation == null)
            {
                return NotFound();
            }



            return _mapper.Map<List<ReservationDTO>>(reservation);
        }


        //// PUT: api/Reservations/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutReservation(int id, Reservation reservation)
        //{
        //    if (id != reservation.ReservationID)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(reservation).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ReservationExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

    }
}
