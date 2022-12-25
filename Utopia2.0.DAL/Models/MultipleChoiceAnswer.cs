using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Utopia2._0.DAL.Models
{
    public class MultipleChoiceAnswer
    {
        // Attributes
        public int Id { get; set; }
        [Required]
        [MinLength(2)]
        public string TextualAnswer { get; set; }
        [Required]
        public bool Active { get; set; }
        [Required]
        public bool Correct { get; set; }
        [Required]
        public int QuestionId { get; set; }

        // Navigation properties
        public Question Question { get; set; }

        public ICollection<Answer> Answers { get; set; }
    }
}
