namespace Utopia2._0.Models
{
    public class Answer
    {
        public int Id { get; set; }
        
        public int MultipleChoiceAnswerId { get; set; }
        public int PersonId { get; set; }
        
        public MultipleChoiceAnswer MultipleChoiceAnswer { get; set; }
    }
}
