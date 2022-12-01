using System.Collections.Generic;

namespace Utopia2._0.Models
{
    public class Lijn
    {
        public int LijnID { get; set; }
        public string Kleur { get; set; }
        public string Faculty { get; set; }

        public ICollection<Gebouw> Gebouwen { get; set; }
    }
}
