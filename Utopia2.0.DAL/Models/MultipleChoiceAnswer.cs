using System.Collections.Generic;

namespace Utopia2._0.Models
{
    public class MultipleChoiceAnswer
    {
        public int Id { get; set; }
        public string TextualAnswer { get; set; }
        public bool Correct { get; set; }
        public int QuestionId { get; set; }
        
        public Question Question { get; set; }

        public ICollection<Answer> Answers { get; set; }
    }
}
