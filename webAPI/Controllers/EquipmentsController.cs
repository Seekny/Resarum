﻿using System;
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
    public class EquipmentsController : ControllerBase
    {
        private readonly EquipmentsManager _equipmentsManager;
        private readonly IMapper _mapper;

        public EquipmentsController(IMapper mapper, EquipmentsManager equipmentsManager)
        {
            _mapper = mapper;
            _equipmentsManager = equipmentsManager;
        }

        // GET: api/Equipments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipmentDTO>>> GetAllEquipments()
        {
            var equipments = await _equipmentsManager.GetEquipments();
            return _mapper.Map<List<EquipmentDTO>>(equipments);
        }

        //// GET: api/Equipments/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Equipment>> GetEquipment(int id)
        //{
        //    var equipment = await _context.Equipments.FindAsync(id);

        //    if (equipment == null)
        //    {
        //        return NotFound();
        //    }

        //    return equipment;
        //}

        //// PUT: api/Equipments/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutEquipment(int id, Equipment equipment)
        //{
        //    if (id != equipment.EquipmentID)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(equipment).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!EquipmentExists(id))
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

        //// POST: api/Equipments
        //[HttpPost]
        //public async Task<ActionResult<Equipment>> PostEquipment(Equipment equipment)
        //{
        //    _context.Equipments.Add(equipment);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetEquipment", new { id = equipment.EquipmentID }, equipment);
        //}

        //// DELETE: api/Equipments/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Equipment>> DeleteEquipment(int id)
        //{
        //    var equipment = await _context.Equipments.FindAsync(id);
        //    if (equipment == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Equipments.Remove(equipment);
        //    await _context.SaveChangesAsync();

        //    return equipment;
        //}

        //private bool EquipmentExists(int id)
        //{
        //    return _context.Equipments.Any(e => e.EquipmentID == id);
        //}
    }
}
