using System;
using System.Collections.Generic;
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
    public class RoomsController : ControllerBase
    {
        private readonly RoomsManager _roomsManager;
        private readonly IMapper _mapper;

        public RoomsController(IMapper mapper, RoomsManager roomsManager)
        {
            _mapper = mapper;
            _roomsManager = roomsManager;
        }

        // GET: api/Rooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomDTO>>> GetAllRooms()
        {
            var rooms = await _roomsManager.GetRooms();
            return _mapper.Map<List<RoomDTO>>(rooms);
        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomDTO>> GetRoom(int id)
        {
            var room = await _roomsManager.GetRoomyById(id);

            if (room == null)
            {
                return NotFound();
            }

            return _mapper.Map<RoomDTO>(room);
        }

        // GET: api/Rooms/5
        [HttpGet("Agency={id}")]
        public async Task<ActionResult<List<RoomDTO>>> GetRoomsByAgencyId(int id)
        {         
            var room = await _roomsManager.GetAllRoomsByAgencyId(id);


            return _mapper.Map<List<RoomDTO>>(room);
        }

    
        // POST: api/Rooms
        [HttpPost]
        public async Task<ActionResult> AddRoomAsync([FromBody]RoomDTO room)
        {
            if (room == null)
            {
                return new EmptyResult();
            }

                // find DTO & Mapping
                var roomMapped = _mapper.Map<RoomDTO, Room>(room);
                //call manager once again to add it this time
                await _roomsManager.AddRoom(roomMapped);

                return Ok();
            }
        }


        //// PUT: api/Rooms/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutRoom(string id, Room room)
        //{
        //    if (id != room.RoomID)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(room).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!RoomExists(id))
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

     

        //// DELETE: api/Rooms/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Room>> DeleteRoom(int id)
        //{
        //    var room = await _context.Rooms.FindAsync(id);
        //    if (room == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Rooms.Remove(room);
        //    await _context.SaveChangesAsync();

        //    return room;
        //}
}

