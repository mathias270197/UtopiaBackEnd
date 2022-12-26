using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Utopia2._0.ApiModels;
using Utopia2._0.DAL.Data;

namespace Utopia2._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BiController : ControllerBase
    {
        private readonly DataContext _context;

        public BiController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PowerBiInput>>> Get()
        {
            List<PowerBiInput> powerBiInput = await _context.Answers
                .Select(a => new PowerBiInput
                {
                    answer = a.MultipleChoiceAnswer.TextualAnswer,
                    isAnswerCorrect = a.MultipleChoiceAnswer.Correct,
                    question = a.MultipleChoiceAnswer.Question.TextualQuestion,
                    graduateProgram = a.MultipleChoiceAnswer.Question.GraduateProgram.Name,
                    faculty = a.MultipleChoiceAnswer.Question.GraduateProgram.Faculty.Name,
                    userName = a.Person.Username,
                    userKey = a.Person.Userkey,
                    date = a.Date
                })
                .ToListAsync();

            return powerBiInput;
        }
    }
}