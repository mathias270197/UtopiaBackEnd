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
    public class BuildingsController : ControllerBase
    {
        private readonly UtopiaContext _context;

        public BuildingsController(UtopiaContext context)
        {
            _context = context;
        }

        // GET: api/Buildings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Building>>> GetBuildings()
        {
            return await _context.Buildings.ToListAsync();
        }

        // GET: api/Buildings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Building>> GetBuilding(int id)
        {
            var building = await _context.Buildings.FindAsync(id);

            if (building == null)
            {
                return NotFound();
            }

            return building;
        }

        /*[HttpGet("GetLineCoordinates/{lineId}")]
        public async Task<ActionResult<IEnumerable<ApiCoordinates>>> GetLineCoordinates(int lineId)
        {

            var buildings = await _context.Buildings
                .Where(b => b.LineId == lineId)
                .OrderBy(c => c.Station.X)
                .Select(b => new ApiCoordinates
                {
                    Id = b.Id,
                    X = b.Station.X,
                    Y = b.Station.Y,
                    Color = b.Line.Color
                })
                .ToListAsync();
            if (buildings == null)
            {
                return NotFound();
            }

            return buildings;
        }
        */
        private bool BuildingExists(int id)
        {
            return _context.Buildings.Any(e => e.Id == id);
        }
    }
}
