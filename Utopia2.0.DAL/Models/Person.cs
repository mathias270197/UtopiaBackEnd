using System.Collections.Generic;

namespace Utopia2._0.DAL.Models
{
    public class Person
    {
        // Attributes
        public int Id { get; set; }
        public string Username { get; set; }
        public string Userkey { get; set; }

        // Navigation properties
        public ICollection<Answer> Answers { get; set; }
    }
}
