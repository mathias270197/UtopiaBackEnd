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
    public class PersonsController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public PersonsController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/Persons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersons()
        {
            var persons = await _uow.PersonRepository.GetAllAsync();
            return persons.ToList();
        }

        // GET: api/Persons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            var person = await _uow.PersonRepository.GetByIDAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            return person;
        }

        // PUT: api/Persons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(int id, Person person)
        {

            if (id != person.Id)
            {
                return BadRequest();
            }

            _uow.PersonRepository.Update(person);

            try
            {
                await _uow.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
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

        // POST: api/Persons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(Person person)
        {
            _uow.PersonRepository.Insert(person);
            await _uow.SaveAsync();

            return CreatedAtAction("GetPerson", new { id = person.Id }, person);
        }

        // DELETE: api/Persons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var person = await _uow.PersonRepository.GetByIDAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            _uow.PersonRepository.Delete(id);
            await _uow.SaveAsync();

            return NoContent();
        }

        private bool PersonExists(int id)
        {
            return _uow.PersonRepository.Get(e => e.Id == id).Any();
        }

        // GET: api/Persons/5/answerswithid                     // Returns a list with one object!
        [HttpGet("{id}/answersviaid")]
        public async Task<ActionResult<IEnumerable<Person>>> GetSinglePersonAnswersViaId(int id)
        {

            var person = await _uow.PersonRepository.GetAsync(
                includes: p => p.Answers,
                filter: p => p.Id == id
                );


            if (person == null)
            {
                return NotFound();
            }

            return person.ToList();
        }

        // GET: api/Persons/5/answersviarandomkey                     // Returns a list with one object!
        [HttpGet("{userkey}/answersviauserkey")]
        public async Task<ActionResult<IEnumerable<Person>>> GetSinglePersonAnswersViaRandomkey(string userkey)
        {

            var person = await _uow.PersonRepository.GetAsync(
                includes: p => p.Answers,
                filter: p => p.Userkey == userkey
                );


            if (person == null)
            {
                return NotFound();
            }

            return person.ToList();
        }
    }
}
