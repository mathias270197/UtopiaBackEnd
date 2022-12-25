using System;
using System.ComponentModel.DataAnnotations;

namespace Utopia2._0.DAL.Models
{
    public class Answer
    {
        // Attributes
        public int Id { get; set; }
        [Required]
        public int MultipleChoiceAnswerId { get; set; }
        [Required]
        public int PersonId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        // Navigation properties
        public Person Person { get; set; }        
        public MultipleChoiceAnswer MultipleChoiceAnswer { get; set; }
    }
}
