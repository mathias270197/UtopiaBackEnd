using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Utopia2._0.DAL.Data;
using Utopia2._0.DAL.Models;

namespace Utopia2._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswersController : ControllerBase
    {

        private readonly IUnitOfWork _uow;

        public AnswersController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/Answers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Answer>>> GetAnswers()
        {
            var answers = await _uow.AnswerRepository.GetAllAsync();
            return answers.ToList();
        }

        // GET: api/Answers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Answer>> GetAnswer(int id)
        {
            var answer = await _uow.AnswerRepository.GetByIDAsync(id);

            if (answer == null)
            {
                return NotFound();
            }

            return answer;
        }

        // PUT: api/Answers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnswer(int id, Answer answer)
        {

            if (id != answer.Id)
            {
                return BadRequest();
            }

            _uow.AnswerRepository.Update(answer);

            try
            {
                await _uow.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnswerExists(id))
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

        // POST: api/Answers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Answer>> PostAnswer(ApiAnswer apiAnswer)
        {
            var answer = new Answer ();
            answer.MultipleChoiceAnswerId = apiAnswer.MultipleChoiceAnswerId;
            
            var ThisPersonAlreadyExists =
                   _uow.PersonRepository.AllQuery()
                   .Where(p => (p.Userkey == apiAnswer.Person.PersonalKey) && (p.Username == apiAnswer.Person.UserName))
                   .Any();

            if (! ThisPersonAlreadyExists)
            {
                //create new person
                var newPerson = new Person ();
                newPerson.Username = apiAnswer.Person.UserName;
                newPerson.Userkey = apiAnswer.Person.PersonalKey;
                _uow.PersonRepository.Insert(newPerson);
                answer.PersonId = newPerson.Id;
            }
            else
            {
                //lookup person
                var person = _uow.PersonRepository.AllQuery()
                                .Where(p => (p.Userkey == apiAnswer.Person.PersonalKey) && (p.Username == apiAnswer.Person.UserName))
                                .FirstOrDefault();

                answer.PersonId = person.Id;
            }

            answer.Date = DateTime.Today;

            _uow.AnswerRepository.Insert(answer);
            await _uow.SaveAsync();

            return CreatedAtAction("GetAnswer", new { id = answer.Id }, answer);
        }

        // DELETE: api/Answers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnswer(int id)
        {
            var answer = await _uow.AnswerRepository.GetByIDAsync(id);
            if (answer == null)
            {
                return NotFound();
            }

            _uow.AnswerRepository.Delete(id);
            await _uow.SaveAsync();

            return NoContent();
        }

        private bool AnswerExists(int id)
        {
            return _uow.AnswerRepository.Get(e => e.Id == id).Any();
        }


    }
}
