using System.Collections.Generic;

namespace Utopia2._0.Models
{
    public class MeerkeuzeAntwoord
    {
        public int Id { get; set; }
        public string TextueelAntwoord { get; set; }
        public bool Correct { get; set; }
        public int VraagId { get; set; }
        
        public Vraag Vraag { get; set; }

        public ICollection<Antwoord> Antwoorden { get; set; }
    }
}
