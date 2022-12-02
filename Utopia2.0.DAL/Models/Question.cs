using System.Collections.Generic;

namespace Utopia2._0.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string TextualQuestion { get; set; }
        public int BuildingId { get; set; }

        public Building Building { get; set; }

        public ICollection<MultipleChoiceAnswer> MultipleChoiceAnswers { get; set; }
        
    }
}
