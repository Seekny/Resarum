using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webAPI.DTO;
using webAPI.Manager;
using webAPI.Models;
using webAPI.Repositories;

namespace webAPI.Controllers
{
    // Effectuer les méthodes dans une classe a part, puis les appeler a partir du manager et du repository ! 

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AgenciesController : ControllerBase
    {
        private readonly AgenciesManager _agenciesManager;
        private readonly IMapper _mapper;

        public AgenciesController( IMapper mapper, AgenciesManager agenciesManager)
        {
            _mapper = mapper;
            _agenciesManager = agenciesManager;
        }

        // GET: api/Agencies
        [HttpGet]
        public async Task<ActionResult<List<AgencyDTO>>> GetAllAgencies()
        {
            var agencies = await _agenciesManager.GetAgencies();
            return _mapper.Map<List<AgencyDTO>>(agencies);
        }

        // GET: api/Agencies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AgencyDTO>> GetAgency(int id)
        {
            var agency = await _agenciesManager.GetAgencyById(id);

            if (agency == null)
            {
                return NotFound();
            }

            return _mapper.Map<AgencyDTO>(agency);
        }

        //// PUT: api/Agencies/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutAgency(int id, Agency agency)
        //{
        //    if (id != agency.AgencyID)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(agency).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!AgencyExists(id))
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

        //// POST: api/Agencies
        //[HttpPost]
        //public async Task<ActionResult<Agency>> PostAgency(Agency agency)
        //{
        //    _context.Agencies.Add(agency);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetAgency", new { id = agency.AgencyID }, agency);
        //}

        //// DELETE: api/Agencies/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Agency>> DeleteAgency(int id)
        //{
        //    var agency = await _context.Agencies.FindAsync(id);
        //    if (agency == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Agencies.Remove(agency);
        //    await _context.SaveChangesAsync();

        //    return agency;
        //}

       
    }
}
