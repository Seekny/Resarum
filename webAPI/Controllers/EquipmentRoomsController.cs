using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webAPI.Manager;
using webAPI.Models;

namespace webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EquipmentRoomsController : ControllerBase
    {
        private readonly EquipmentRoomsManager _equipmentRoomsManager;
        private readonly IMapper _mapper;

        public EquipmentRoomsController(IMapper mapper, EquipmentRoomsManager equipmentRoomsManager)
        {
            _mapper = mapper;
            _equipmentRoomsManager = equipmentRoomsManager;
        }
                
        // GET: api/EquipmentRooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<EquipmentRooms>>> GetEquipmentRoom(int id)
        {
            var equipmentRooms = await _equipmentRoomsManager.GetEquipmentsByRoomID(id);
            return _mapper.Map<List<EquipmentRooms>>(equipmentRooms);
        }
    }

    //    //// GET: api/EquipmentRooms
    //    //[HttpGet]
    //    //public async Task<ActionResult<IEnumerable<EquipmentRooms>>> GetEquipmentsRooms()
    //    //{
    //    //    return await _context.EquipmentsRooms.ToListAsync();
    //    //}


    //    // PUT: api/EquipmentRooms/5
    //    [HttpPut("{id}")]
    //    public async Task<IActionResult> PutEquipmentRoom(int id, EquipmentRooms equipmentRoom)
    //    {
    //        if (id != equipmentRoom.EquipmentID)
    //        {
    //            return BadRequest();
    //        }

    //        _context.Entry(equipmentRoom).State = EntityState.Modified;

    //        try
    //        {
    //            await _context.SaveChangesAsync();
    //        }
    //        catch (DbUpdateConcurrencyException)
    //        {
    //            if (!EquipmentRoomExists(id))
    //            {
    //                return NotFound();
    //            }
    //            else
    //            {
    //                throw;
    //            }
    //        }

    //        return NoContent();
    //    }

    //    // POST: api/EquipmentRooms
    //    [HttpPost]
    //    public async Task<ActionResult<EquipmentRooms>> PostEquipmentRoom(EquipmentRooms equipmentRoom)
    //    {
    //        _context.EquipmentsRooms.Add(equipmentRoom);
    //        try
    //        {
    //            await _context.SaveChangesAsync();
    //        }
    //        catch (DbUpdateException)
    //        {
    //            if (EquipmentRoomExists(equipmentRoom.EquipmentID))
    //            {
    //                return Conflict();
    //            }
    //            else
    //            {
    //                throw;
    //            }
    //        }

    //        return CreatedAtAction("GetEquipmentRoom", new { id = equipmentRoom.EquipmentID }, equipmentRoom);
    //    }

    //    // DELETE: api/EquipmentRooms/5
    //    [HttpDelete("{id}")]
    //    public async Task<ActionResult<EquipmentRooms>> DeleteEquipmentRoom(int id)
    //    {
    //        var equipmentRoom = await _context.EquipmentsRooms.FindAsync(id);
    //        if (equipmentRoom == null)
    //        {
    //            return NotFound();
    //        }

    //        _context.EquipmentsRooms.Remove(equipmentRoom);
    //        await _context.SaveChangesAsync();

    //        return equipmentRoom;
    //    }

    //    private bool EquipmentRoomExists(int id)
    //    {
    //        return _context.EquipmentsRooms.Any(e => e.EquipmentID == id);
    //    }
    //}
}
