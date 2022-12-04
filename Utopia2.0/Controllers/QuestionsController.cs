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
    public class QuestionsController : ControllerBase
    {
        private readonly UtopiaContext _context;

        public QuestionsController(UtopiaContext context)
        {
            _context = context;
        }


        [HttpGet("GetEscapeRoom/{buildingID}")]
        public async Task<ActionResult<IEnumerable<ApiQuestion>>> GetEscapeRoom(int buildingId)
        {
            var questions = await _context.Questions
                .Where(q => q.BuildingId == buildingId)
                .Select(q => new ApiQuestion
                {
                    Id = q.Id,
                    TextualQuestion = q.TextualQuestion,
                    Ansers = q.MultipleChoiceAnswers.Select(a => new ApiMultipleChoiceAnswer { Id = a.Id, TextualAnswer = a.TextualAnswer }).ToList()
                })
                .ToListAsync();

            if (questions == null)
            {
                return NotFound();
            }

            return questions;
        }

        [HttpPost("PostAnswers")]
        public async Task<ActionResult<ApiCorrectAnswersAndPoints>> PostCompany([FromBody] ApiAnswer apiAnswer)
        {

            var person = await _context.Persons
                .Where(p => (p.RandomKey == apiAnswer.PersonalKey) && (p.Username == apiAnswer.UserName))
                .FirstOrDefaultAsync();

            foreach (int multipleChoiceAnswerId in apiAnswer.MultipleChoiceAnswerIds)
            {
                _context.Answers.Add(new Answer { MultipleChoiceAnswerId = multipleChoiceAnswerId, PersonId = person.Id });
                await _context.SaveChangesAsync();
            }

            //logica voor punten toevoegen

            //antwoordenID's ook toevoegen

            return new ApiCorrectAnswersAndPoints { CorrectAnswerIds = { 1, 2, 3 }, points = 10};
        }




    }
}
