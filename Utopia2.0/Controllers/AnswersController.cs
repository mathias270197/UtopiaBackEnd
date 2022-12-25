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
        public async Task<ActionResult<Answer>> PostAnswer(Answer answer)
        {
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















        //private readonly UtopiaContext _context;

        //public AnswersController(UtopiaContext context)
        //{
        //    _context = context;
        //}

        //// GET: api/Answers
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Answer>>> GetAnswers()
        //{
        //    return await _context.Answers.ToListAsync();
        //}

        //// GET: api/Answers/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Answer>> GetAnswer(int id)
        //{
        //    var answer = await _context.Answers.FindAsync(id);

        //    if (answer == null)
        //    {
        //        return NotFound();
        //    }

        //    return answer;
        //}

        //// PUT: api/Answers/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutAnswer(int id, Answer answer)
        //{
        //    if (id != answer.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(answer).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!AnswerExists(id))
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

        //// POST: api/Answers
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Answer>> PostAnswer(Answer answer)
        //{
        //    _context.Answers.Add(answer);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetAnswer", new { id = answer.Id }, answer);
        //}

        //// DELETE: api/Answers/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteAnswer(int id)
        //{
        //    var answer = await _context.Answers.FindAsync(id);
        //    if (answer == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Answers.Remove(answer);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool AnswerExists(int id)
        //{
        //    return _context.Answers.Any(e => e.Id == id);
        //}
    }
}
