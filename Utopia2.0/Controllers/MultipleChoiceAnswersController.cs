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
    public class MultipleChoiceAnswersController : ControllerBase
    {

        private readonly IUnitOfWork _uow;

        public MultipleChoiceAnswersController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/MultipleChoiceAnswers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MultipleChoiceAnswer>>> GetMultipleChoiceAnswers()
        {
            var multipleChoiceAnswers = await _uow.MultipleChoiceAnswerRepository.GetAllAsync();
            return multipleChoiceAnswers.ToList();
        }

        // GET: api/MultipleChoiceAnswers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MultipleChoiceAnswer>> GetMultipleChoiceAnswer(int id)
        {
            var multipleChoiceAnswer = await _uow.MultipleChoiceAnswerRepository.GetByIDAsync(id);

            if (multipleChoiceAnswer == null)
            {
                return NotFound();
            }

            return multipleChoiceAnswer;
        }

        // PUT: api/MultipleChoiceAnswers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMultipleChoiceAnswer(int id, MultipleChoiceAnswer multipleChoiceAnswer)
        {

            if (id != multipleChoiceAnswer.Id)
            {
                return BadRequest();
            }

            _uow.MultipleChoiceAnswerRepository.Update(multipleChoiceAnswer);

            try
            {
                await _uow.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MultipleChoiceAnswerExists(id))
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

        // POST: api/MultipleChoiceAnswers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MultipleChoiceAnswer>> PostMultipleChoiceAnswer(MultipleChoiceAnswer multipleChoiceAnswer)
        {
            _uow.MultipleChoiceAnswerRepository.Insert(multipleChoiceAnswer);
            await _uow.SaveAsync();

            return CreatedAtAction("GetMultipleChoiceAnswer", new { id = multipleChoiceAnswer.Id }, multipleChoiceAnswer);
        }

        // DELETE: api/MultipleChoiceAnswers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMultipleChoiceAnswer(int id)
        {
            var multipleChoiceAnswer = await _uow.MultipleChoiceAnswerRepository.GetByIDAsync(id);
            if (multipleChoiceAnswer == null)
            {
                return NotFound();
            }

            _uow.MultipleChoiceAnswerRepository.Delete(id);
            await _uow.SaveAsync();

            return NoContent();
        }

        private bool MultipleChoiceAnswerExists(int id)
        {
            return _uow.MultipleChoiceAnswerRepository.Get(e => e.Id == id).Any();
        }
    }
}
