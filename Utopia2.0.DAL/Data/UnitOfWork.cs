using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utopia2._0.DAL.Models;

namespace Utopia2._0.DAL.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private DataContext _context;
        private GenericRepository<Faculty> facultyRepository;
        private GenericRepository<GraduateProgram> graduateProgramRepository;
        private GenericRepository<Question> questionRepository;
        private GenericRepository<MultipleChoiceAnswer> multipleChoiceAnswerRepository;
        private GenericRepository<Person> personRepository;
        private GenericRepository<Answer> answerRepository;


        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public GenericRepository<Faculty> FacultyRepository
        {
            get
            {
                if (facultyRepository == null)
                {
                    facultyRepository = new GenericRepository<Faculty>(_context);
                }
                return facultyRepository;
            }
        }

        public GenericRepository<GraduateProgram> GraduateProgramRepository
        {
            get
            {
                if (graduateProgramRepository == null)
                {
                    graduateProgramRepository = new GenericRepository<GraduateProgram>(_context);
                }
                return graduateProgramRepository;
            }
        }

        public GenericRepository<Question> QuestionRepository
        {
            get
            {
                if (questionRepository == null)
                {
                    questionRepository = new GenericRepository<Question>(_context);
                }
                return questionRepository;
            }
        }

        public GenericRepository<MultipleChoiceAnswer> MultipleChoiceAnswerRepository
        {
            get
            {
                if (multipleChoiceAnswerRepository == null)
                {
                    multipleChoiceAnswerRepository = new GenericRepository<MultipleChoiceAnswer>(_context);
                }
                return multipleChoiceAnswerRepository;
            }
        }

        public GenericRepository<Person> PersonRepository
        {
            get
            {
                if (personRepository == null)
                {
                    personRepository = new GenericRepository<Person>(_context);
                }
                return personRepository;
            }
        }

        public GenericRepository<Answer> AnswerRepository
        {
            get
            {
                if (answerRepository == null)
                {
                    answerRepository = new GenericRepository<Answer>(_context);
                }
                return answerRepository;
            }
        }




        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
