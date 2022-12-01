using System.Collections.Generic;

namespace Utopia2._0.Models
{
    public class Persoon
    {
        public int Id { get; set; }
        public string gebruikersNaam { get; set; }
        public int RandomKey { get; set; }

        public ICollection<Antwoord> Antwoorden { get; set; }
    }
}
