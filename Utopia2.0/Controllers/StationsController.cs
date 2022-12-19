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

                
            return await _context.Lines.Include(l => l.Buildings)
                .Select(c => new ApiStation
                {
                    Id = c.Id ,
                    Coordinates = _context.Buildings.Where(b => b.LineId == c.Id).OrderBy(c => c.Station.X).Select(x => new ApiCoordinates
                    {
                        X = x.Station.X,
                        Y = x.Station.Y
                    }).ToList(),
                    Color = c.Color,
                    
                    //maximum te verdienen punten nog toevoegen
                })
                .ToListAsync();
        }

        [HttpGet("GetEscapeRoomsOfStation/{stationId}")]
        public async Task<ActionResult<IEnumerable<ApiBuilding>>> GetEscapeRoomsOfStation(int stationId)
        {



            var buildings = await _context.Buildings
                .Where(b => b.StationId == stationId)
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





    }
}