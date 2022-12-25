using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utopia2._0.DAL.Models;

namespace Utopia2._0.DAL.Models
{
    public class Question
    {
        // Attributes
        public int Id { get; set; }
        [Required]
        [MinLength(2)]
        public string TextualQuestion { get; set; }
        [Required]
        public bool Active { get; set; }
        [Required]
        public int GraduateProgramId { get; set; }

        // Navigation properties
        public GraduateProgram GraduateProgram { get; set; }

        public ICollection<MultipleChoiceAnswer> MultipleChoiceAnswers { get; set; }
        
    }
}
