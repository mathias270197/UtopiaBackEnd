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
                })
                .ToListAsync();

            return powerBiInput;
        }









        //[HttpGet("GetAnswers")]
        //public async Task<ActionResult<IEnumerable<Answer>>> GetAnswers()
        //{
        //    return await _context.Answers.ToListAsync();
        //}

        //[HttpGet("GetBuildings")]
        //public async Task<ActionResult<IEnumerable<Building>>> GetBuildings()
        //{
        //    return await _context.Buildings.ToListAsync();
        //}

        //[HttpGet("GetLines")]
        //public async Task<ActionResult<IEnumerable<Line>>> GetLines()
        //{
        //    return await _context.Lines.ToListAsync();
        //}

        //[HttpGet("GetMultipleChoiceAnswers")]
        //public async Task<ActionResult<IEnumerable<MultipleChoiceAnswer>>> GetMultipleChoiceAnswer()
        //{
        //    return await _context.MultipleChoiceAnswers.ToListAsync();
        //}

        //[HttpGet("GetPersons")]
        //public async Task<ActionResult<IEnumerable<Person>>> GetPersons()
        //{
        //    return await _context.Persons.ToListAsync();
        //}

        //[HttpGet("GetQuestions")]
        //public async Task<ActionResult<IEnumerable<Question>>> GetQuestions()
        //{
        //    return await _context.Questions.ToListAsync();
        //}

        //[HttpGet("GetStations")]
        //public async Task<ActionResult<IEnumerable<Station>>> GetStations()
        //{
        //    return await _context.Stations.ToListAsync();
        //}


    }
}