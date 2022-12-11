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


        [HttpGet("GetEscapeRoom/{buildingId}")]
        public async Task<ActionResult<IEnumerable<ApiQuestion>>> GetEscapeRoom(int buildingId)
        {
            var questions = await _context.Questions
                .Where(q => q.BuildingId == buildingId)
                .Select(q => new ApiQuestion
                {
                    Id = q.Id,
                    TextualQuestion = q.TextualQuestion,
                    Ansers = q.MultipleChoiceAnswers.Select(m => new ApiMultipleChoiceAnswer { Id = m.Id, TextualAnswer = m.TextualAnswer, Correct = m.Correct  }).ToList()
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
            var points = 0;

            var person = await _context.Persons
                .Where(p => (p.RandomKey == apiAnswer.PersonalKey) && (p.Username == apiAnswer.UserName))
                .FirstOrDefaultAsync();

            //find lineId of the questions that you filled in
            var lineId = _context.MultipleChoiceAnswers
                    .Where(m => m.Id == apiAnswer.MultipleChoiceAnswerIds.FirstOrDefault())
                    .FirstOrDefaultAsync()
                    .Result
                    .Question
                    .Building
                    .LineId;

            var DidThisPersonAlreadyAnswerQuestionsOnThisLine =
                _context.Answers
                .Where(a => a.PersonId == person.Id)
                .Where(a => a.MultipleChoiceAnswer.Question.Building.LineId == lineId)
                .Any();

            foreach (int multipleChoiceAnswerId in apiAnswer.MultipleChoiceAnswerIds)
            {
                _context.Answers.Add(new Answer { MultipleChoiceAnswerId = multipleChoiceAnswerId, PersonId = person.Id });
                await _context.SaveChangesAsync();


                //check if answer is correct
                var isCorrect = _context.MultipleChoiceAnswers
                    .Where(m => m.Id == multipleChoiceAnswerId)
                    .FirstOrDefaultAsync()
                    .Result
                    .Correct;
                if (isCorrect)
                {
                    points++;
                }

            }
                        

            if (!DidThisPersonAlreadyAnswerQuestionsOnThisLine)
            {
                //add bonus factor x2
                points *= 2;
            }

            return new ApiCorrectAnswersAndPoints { CorrectAnswerIds = { 1, 2, 3 }, points = points};
        }




    }
}
