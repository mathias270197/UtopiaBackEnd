using System.Collections.Generic;

namespace Utopia2._0.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string RandomKey { get; set; }

        public ICollection<Answer> Answers { get; set; }
    }
}
