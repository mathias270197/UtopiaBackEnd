using System;
using System.ComponentModel.DataAnnotations;

namespace Utopia2._0.Models
{
    public class Answer
    {
        public int Id { get; set; }
        
        public int MultipleChoiceAnswerId { get; set; }
        public int PersonId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public Person Person { get; set; }        
        public MultipleChoiceAnswer MultipleChoiceAnswer { get; set; }
    }
}
