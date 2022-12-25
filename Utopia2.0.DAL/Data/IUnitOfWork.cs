using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utopia2._0.DAL.Models;

namespace Utopia2._0.DAL.Data
{
    public interface IUnitOfWork
    {
        GenericRepository<Faculty> FacultyRepository { get; }
        GenericRepository<GraduateProgram> GraduateProgramRepository { get; }
        GenericRepository<Question> QuestionRepository { get; }
        GenericRepository<MultipleChoiceAnswer> MultipleChoiceAnswerRepository { get; }
        GenericRepository<Person> PersonRepository { get; }
        GenericRepository<Answer> AnswerRepository { get; }



        Task SaveAsync();
    }
}
