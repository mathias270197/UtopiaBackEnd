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
    public class FacultiesController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public FacultiesController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/Faculties
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Faculty>>> GetFaculties()
        {
            var faculties = await _uow.FacultyRepository.GetAllAsync();
            return faculties.ToList();
        }

        // GET: api/Faculties/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Faculty>> GetFaculty(int id)
        {
            var faculty = await _uow.FacultyRepository.GetByIDAsync(id);

            if (faculty == null)
            {
                return NotFound();
            }

            return faculty;
        }

        // PUT: api/Faculties/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFaculty(int id, Faculty faculty)
        {

            if (id != faculty.Id)
            {
                return BadRequest();
            }

            _uow.FacultyRepository.Update(faculty);

            try
            {
                await _uow.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacultyExists(id))
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

        // POST: api/Faculties
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Faculty>> PostFaculty(Faculty faculty)
        {
            _uow.FacultyRepository.Insert(faculty);
            await _uow.SaveAsync();

            return CreatedAtAction("GetFaculty", new { id = faculty.Id }, faculty);
        }

        // DELETE: api/Faculties/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFaculty(int id)
        {
            var faculty = await _uow.FacultyRepository.GetByIDAsync(id);
            if (faculty == null)
            {
                return NotFound();
            }

            _uow.FacultyRepository.Delete(id);
            await _uow.SaveAsync();

            return NoContent();
        }

        private bool FacultyExists(int id)
        {
            return _uow.FacultyRepository.Get(e => e.Id == id).Any();
        }

        // GET: api/Faculties/graduateprograms
        [HttpGet("graduateprograms")]
        public async Task<ActionResult<IEnumerable<Faculty>>> GetGraduatePrograms()
        {
            var faculties = await _uow.FacultyRepository.GetAsync(
                includes: f => f.GraduatePrograms,
                filter: f => f.Active == true
                );
            return faculties.ToList();
        }

        // GET: api/Faculties/5/graduateprograms                     // Returns a list with one object!
        [HttpGet("{id}/graduateprograms")]
        public async Task<ActionResult<IEnumerable<Faculty>>> GetSingleFacultyGraduatePrograms(int id)
        {
            var faculty = await _uow.FacultyRepository.GetAsync(
                includes: f => f.GraduatePrograms.Where(g => g.Active == true),
                filter: f => f.Id == id
                );

            if (faculty == null)
            {
                return NotFound();
            }

            return faculty.ToList();
        }


    }
}
