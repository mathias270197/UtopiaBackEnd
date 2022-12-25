using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utopia2._0.DAL.Data;
using Utopia2._0.DAL.Models;

namespace Utopia2._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GraduateProgramsController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly DataContext _context;

        public GraduateProgramsController(IUnitOfWork uow, DataContext context)
        {
            _uow = uow;
            _context = context;
        }

        // GET: api/GraduatePrograms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GraduateProgram>>> GetGraduatePrograms()
        {
            var graduatePrograms = await _uow.GraduateProgramRepository.GetAllAsync();
            return graduatePrograms.ToList();
        }

        // GET: api/GraduatePrograms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GraduateProgram>> GetGraduateProgram(int id)
        {
            var graduateProgram = await _uow.GraduateProgramRepository.GetByIDAsync(id);

            if (graduateProgram == null)
            {
                return NotFound();
            }

            return graduateProgram;
        }

        // PUT: api/GraduatePrograms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGraduateProgram(int id, GraduateProgram graduateProgram)
        {

            if (id != graduateProgram.Id)
            {
                return BadRequest();
            }

            _uow.GraduateProgramRepository.Update(graduateProgram);

            try
            {
                await _uow.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GraduateProgramExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        // POST: api/GraduatePrograms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GraduateProgram>> PostGraduateProgram(GraduateProgram graduateProgram)
        {
            _uow.GraduateProgramRepository.Insert(graduateProgram);
            await _uow.SaveAsync();

            return CreatedAtAction("GetGraduateProgram", new { id = graduateProgram.Id }, graduateProgram);
        }

        // DELETE: api/GraduatePrograms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGraduateProgram(int id)
        {
            var graduateProgram = await _uow.GraduateProgramRepository.GetByIDAsync(id);
            if (graduateProgram == null)
            {
                return NotFound();
            }

            _uow.GraduateProgramRepository.Delete(id);
            await _uow.SaveAsync();

            return NoContent();
        }

        private bool GraduateProgramExists(int id)
        {
            return _uow.GraduateProgramRepository.Get(e => e.Id == id).Any();
        }


        // GET: api/GraduatePrograms/questions
        [HttpGet("questions")]
        public async Task<ActionResult<IEnumerable<GraduateProgram>>> GetQuestions()
        {
            var graduatePrograms = await _uow.GraduateProgramRepository.GetAsync(
                includes: g => g.Questions.Where(q => q.Active == true),
                filter: g => g.Active == true
                );
            return graduatePrograms.ToList();
        }

        // GET: api/GraduatePrograms/5/multiplechoiceanswers                     // Returns a list with one object!
        [HttpGet("{id}/multiplechoiceanswers")]
        public async Task<ActionResult<IEnumerable<GraduateProgram>>> GetSingleGraduateProgramMultipleChoiceAnswers(int id)
        {


            //var graduateProgram = await _uow.GraduateProgramRepository.GetAsync(
            //    includes: g => g.Questions.Where(q => q.Active == true),
            //    filter: g => g.Id == id
            //    );

            var graduateProgram = _context.GraduatePrograms
                .Where(g => g.Id == id)
                .Include(g => g.Questions.Where(q => q.Active == true))
                .ThenInclude(q => q.MultipleChoiceAnswers)
                .ToList();

            if (graduateProgram == null)
            {
                return NotFound();
            }

            return graduateProgram;
        }

    }
}
