using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Utopia2._0.Data;
using Utopia2._0.Models;

namespace Utopia2._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StationsController : ControllerBase
    {
        private readonly UtopiaContext _context;

        public StationsController(UtopiaContext context)
        {
            _context = context;
        }

        [HttpGet("GetStations")]
        public async Task<ActionResult<IEnumerable<ApiStation>>> GetStations()
        {
            return await _context.Stations
                .Select(s => new ApiStation
                { 
                    Id = s.Id,
                    X = s.X,
                    Y =s.Y
                })
                .ToListAsync();
        }

        [HttpGet("GetEscapeRoomsOfStation/{stationId}")]
        public async Task<ActionResult<IEnumerable<ApiBuilding>>> GetEscapeRoomsOfStation(int id)
        {
            var buildings = await _context.Buildings
                .Where(b => b.StationId == id)
                .Select(b => new ApiBuilding
                {
                    Id = b.Id,
                    GraduateProgram = b.GraduateProgram,
                    Color = b.Line.Color
                })
                .ToListAsync();
            // with buildings (ID en name)

            if (buildings == null)
            {
                return NotFound();
            }

            return buildings;
        }





        //// PUT: api/Stations/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutStation(int id, Models.Station station)
        //{
        //    if (id != station.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(station).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!StationExists(id))
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

        //// POST: api/Stations
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Models.Station>> PostStation(Models.Station station)
        //{
        //    _context.Stations.Add(station);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetStation", new { id = station.Id }, station);
        //}

        //// DELETE: api/Stations/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteStation(int id)
        //{
        //    var station = await _context.Stations.FindAsync(id);
        //    if (station == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Stations.Remove(station);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool StationExists(int id)
        //{
        //    return _context.Stations.Any(e => e.Id == id);
        //}
    }
}