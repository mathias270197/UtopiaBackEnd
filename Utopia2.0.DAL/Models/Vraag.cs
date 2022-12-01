using System.Collections.Generic;

namespace Utopia2._0.Models
{
    public class Vraag
    {
        public int Id { get; set; }
        public string TextueleVraag { get; set; }
        public int GebouwId { get; set; }

        public Gebouw Gebouw { get; set; }

        public ICollection<MeerkeuzeAntwoord> MeerKeuzeAntwoorden { get; set; }
        public ICollection<Antwoord> Antwoorden { get; set; }
    }
}
