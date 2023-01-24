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
    public class QuestionsController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public QuestionsController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/Questions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Question>>> GetQuestions()
        {
            var questions = await _uow.QuestionRepository.GetAllAsync();
            return questions.ToList();
        }

        // GET: api/Questions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Question>> GetQuestion(int id)
        {
            var question = await _uow.QuestionRepository.GetByIDAsync(id);

            if (question == null)
            {
                return NotFound();
            }

            return question;
        }

        // PUT: api/Questions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestion(int id, Question question)
        {

            if (id != question.Id)
            {
                return BadRequest();
            }

            _uow.QuestionRepository.Update(question);

            try
            {
                await _uow.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionExists(id))
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

        // POST: api/Questions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Question>> PostQuestion(Question question)
        {
            _uow.QuestionRepository.Insert(question);
            await _uow.SaveAsync();

            return CreatedAtAction("GetQuestion", new { id = question.Id }, question);
        }

        // DELETE: api/Questions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            var question = await _uow.QuestionRepository.GetByIDAsync(id);
            if (question == null)
            {
                return NotFound();
            }

            _uow.QuestionRepository.Delete(id);
            await _uow.SaveAsync();

            return NoContent();
        }

        private bool QuestionExists(int id)
        {
            return _uow.QuestionRepository.Get(e => e.Id == id).Any();
        }


        // GET: api/Questions/5/multiplechoiceanswers                             // Returns a list with one object!
        [HttpGet("{id}/multiplechoiceanswers")]
        public async Task<ActionResult<IEnumerable<Question>>> GetSingleQuestionMultipleChoiceAnswers(int id)
        {

            var question = await _uow.QuestionRepository.GetAsync(
             includes: q => q.MultipleChoiceAnswers.Where(m => m.Active == true),
             filter: q => q.Id == id
             );
            return question.ToList();

        }



    }
}
